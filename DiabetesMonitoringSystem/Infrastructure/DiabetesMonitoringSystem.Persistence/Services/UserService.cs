using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DiabetesMonitoringSystem.Application.DTOs.UserDTOs;
using DiabetesMonitoringSystem.Application.Services;
using DiabetesMonitoringSystem.Domain.Entities;
using DiabetesMonitoringSystem.Infrastructure.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DiabetesMonitoringSystem.Persistence.Services
{
    public class UserService(UserManager<AppUser> usermanager,SignInManager<AppUser> signInManager,IJwtService jwtService,IMapper mapper,IMailService mailService) : IUserService
    {
        public async Task<IdentityResult> CreateDoctorAsync(DoctorRegisterDto doctorRegisterDto)
        {
            var user = mapper.Map<AppUser>(doctorRegisterDto);

            var result = await usermanager.CreateAsync(user, doctorRegisterDto.Password);

            if (result.Succeeded)
            {
                await usermanager.AddToRoleAsync(user, "Doktor");
                return result;
            }

            return result;
        }

        public string GenerateRandomPassword(int length = 10)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789*";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public async Task<IdentityResult> CreatePatientAsync(PatientRegisterDto patientRegisterDto)
        {
            var user = mapper.Map<AppUser>(patientRegisterDto);
            var randomPassword = GenerateRandomPassword()+"1*";
            user.UserName = user.FirstName;

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

        public async Task<string?> LoginAsync(UserLoginDto userLoginDto)
        {
            var user = await usermanager.Users.FirstOrDefaultAsync(u => u.TC == userLoginDto.TC);
            if (user == null)
                return null;

            var result = await signInManager.PasswordSignInAsync(user, userLoginDto.Password, false, false);
            if (!result.Succeeded)
            {
                return null;
            }
            var token = await jwtService.CreateTokenAsync(user);
            return token;
        }

        public async Task LogoutAsync()
        {
            await signInManager.SignOutAsync();
        }
    }
}
