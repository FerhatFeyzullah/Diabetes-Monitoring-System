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
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public async Task<IdentityResult> CreatePatientAsync(PatientRegisterDto patientRegisterDto)
        {
            var user = mapper.Map<AppUser>(patientRegisterDto);
            var randomPassword = GenerateRandomPassword(); 

            var result = await usermanager.CreateAsync(user, randomPassword);
            if (result.Succeeded)
            {
                await usermanager.AddToRoleAsync(user, "Hasta");
                await mailService.SendEmailAsync(user.Email, "Diyabet Takip Sistemine Hoş Geldiniz - Giriş Bilgileriniz!",
                    $"Sayın {user.FirstName} {user.LastName} ,\r\n\r\nDiyabet Takip Sistemine hoş geldiniz.\r\n\r\n" +
                    "Sistemimize giriş yapabilmeniz için oluşturulan geçici şifreniz aşağıda yer almaktadır:\r\n\r\n" +
                    $"🔐 Giriş Şifreniz:{randomPassword}\r\n\r\n⚠️ Bu şifre sadece size özeldir." +
                    "Güvenliğiniz açısından bu bilgiyi doktorunuz dahil kimseyle paylaşmayınız.\r\n\r\n" +
                    "İlk girişinizden sonra şifrenizi değiştirmenizi önemle tavsiye ederiz.\r\n\r\n" +
                    "Sağlıklı günler dileriz." + "  \r\nDiyabet Takip Sistemi Destek Ekibi\r\n\r\n");
                    
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
