using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DiabetesMonitoringSystem.Application.DTOs.UserDTOs;
using DiabetesMonitoringSystem.Application.Services;
using DiabetesMonitoringSystem.Domain.Entities;
using DiabetesMonitoringSystem.Infrastructure.Interfaces;
using DiabetesMonitoringSystem.Persistence.DbContext;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DiabetesMonitoringSystem.Persistence.Services
{
    public class UserService(UserManager<AppUser> usermanager,SignInManager<AppUser> signInManager,
        IJwtService jwtService,IMapper mapper,IMailService mailService,
        IFileStorageService fileStorageService, DiabetesDbContext _context) : IUserService
    {
        private readonly DiabetesDbContext context = _context;
      
        
        public async Task<IdentityResult> CreateDoctorAsync(DoctorRegisterDto doctorRegisterDto)
        {
            var user = mapper.Map<AppUser>(doctorRegisterDto);


            var existingUser = await usermanager.FindByNameAsync(doctorRegisterDto.TC);
            if (existingUser != null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "Bu TC kimlik numarasıyla kayıtlı zaten bir kullanıcı var." });
            }

            var existingEmailUser = await usermanager.FindByEmailAsync(doctorRegisterDto.Email);
            if (existingEmailUser != null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "Bu e-posta adresiyle kayıtlı zaten bir kullanıcı var." });
            }


            user.UserName = doctorRegisterDto.TC;
            var result = await usermanager.CreateAsync(user, doctorRegisterDto.Password);

            if (result.Succeeded)
            {
                await usermanager.AddToRoleAsync(user, "Doktor");
                return result;
            }

            return result;
        }

        private string GenerateRandomPassword(int length = 10)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789*";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public async Task<IdentityResult> CreatePatientAsync(PatientRegisterDto patientRegisterDto)
        {
            var user = mapper.Map<AppUser>(patientRegisterDto);


            var existingUser = await usermanager.FindByNameAsync(patientRegisterDto.TC);
            if (existingUser != null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "Bu TC kimlik numarasıyla kayıtlı zaten bir kullanıcı var." });
            }

            var existingEmailUser = await usermanager.FindByEmailAsync(patientRegisterDto.Email);
            if (existingEmailUser != null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "Bu e-posta adresiyle kayıtlı zaten bir kullanıcı var." });
            }



            var randomPassword = GenerateRandomPassword()+"1*";
            user.UserName = patientRegisterDto.TC;

            var result = await usermanager.CreateAsync(user, randomPassword);
            if (result.Succeeded)
            {
                await usermanager.AddToRoleAsync(user, "Hasta");

                string htmlBody = $@"
                    <div style='font-family: Arial, sans-serif; padding: 20px; color: #333;'>
                        <h2 style='color: #2c3e50;'>👋 Hoş Geldiniz, {user.FirstName} {user.LastName}</h2>

                        <p>Diyabet Takip Sistemine kayıt işleminiz başarıyla tamamlandı.</p>

                        <p><strong>📌 Giriş Bilgileriniz:</strong></p>
                        <div style='background-color: #f1f1f1; border-left: 6px solid #3498db; padding: 12px; font-size: 16px;'>
                            <strong>🔐 Geçici Şifreniz:</strong> {randomPassword}
                        </div>

                        <p style='margin-top: 20px;'>
                            ⚠️ Bu şifre sadece size özeldir. Güvenliğiniz için <strong>doktorunuz dahil</strong> kimseyle paylaşmayınız.
                        </p>

                        <p>
                            İlk girişinizin ardından <strong>şifrenizi değiştirmeniz önemle tavsiye edilir</strong>.
                        </p>

                        <hr style='margin-top: 30px;' />
                        <p style='font-size: 13px; color: #999;'>
                            Sağlıklı günler dileriz.<br />
                            <strong>Diyabet Takip Sistemi Destek Ekibi</strong>
                        </p>
                    </div>";

                await mailService.SendEmailAsync(user.Email, "Diyabet Takip Sistemine Hoş Geldiniz - Giriş Bilgileriniz!", htmlBody,isHtml:true);
                    
            }
           
            return result;
        }

        public async Task<UserLoginResponseDto> LoginAsync(UserLoginDto userLoginDto)
        {
            var user = await usermanager.FindByNameAsync(userLoginDto.TC);
            if (user == null) 
            {
                return new UserLoginResponseDto
                {
                    Success = false,
                    Message = "Bu TC kimlik numarasıyla kayıtlı bir kullanıcı bulunamadı."
                };
            }
                

            var result = await signInManager.PasswordSignInAsync(user, userLoginDto.Password, false, false);
            if (!result.Succeeded)
            {
                return new UserLoginResponseDto
                {
                    Success = false,
                    Message = "Şifre yanlış"
                };
            }

            

            var token = await jwtService.CreateTokenAsync(user);
            return new UserLoginResponseDto
            {
                Success = true,
                Message = token
            };
        }

        public async Task LogoutAsync()
        {
            await signInManager.SignOutAsync();
        }

        public async Task UploadImage(int patientId, IFormFile image)
        {
            var imageId = await fileStorageService.UploadImage(image);

            var user = await context.Users.FindAsync(patientId);
            if (user != null)
            {
                user.ProfilePhotoId = imageId;
                context.Users.Update(user);
                await context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("User not found");
            }
        }

        public async Task<IdentityResult> ChangePassword(int appUserId, string oldPass, string newPass, string confNewPass)
        {
            var user = await usermanager.FindByIdAsync(appUserId.ToString());

            bool isOldPasswordValid = await usermanager.CheckPasswordAsync(user, oldPass);
            if (!isOldPasswordValid)
            {
                return IdentityResult.Failed(new IdentityError { Description = "Eski şifre yanlış" });
            }
            if (newPass != confNewPass)
            {
                return IdentityResult.Failed(new IdentityError { Description = "Yeni şifreler eşleşmiyor" });
            }

            return await usermanager.ChangePasswordAsync(user, oldPass, newPass);


        }

        public async Task<IdentityResult> ChangeForgotPassword(string email, string newPass, string confNewPass)
        {
            var user = await usermanager.FindByEmailAsync(email);
            if (newPass != confNewPass)
            {
                return IdentityResult.Failed(new IdentityError { Description = "Yeni şifreler eşleşmiyor" });
            }

            var token = await usermanager.GeneratePasswordResetTokenAsync(user);
            var result = await usermanager.ResetPasswordAsync(user, token, newPass);
            return result;

        }
    }
}
