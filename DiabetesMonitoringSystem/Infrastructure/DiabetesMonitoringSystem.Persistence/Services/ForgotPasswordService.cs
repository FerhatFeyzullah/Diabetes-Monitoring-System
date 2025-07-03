using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiabetesMonitoringSystem.Application.Services;
using DiabetesMonitoringSystem.Domain.Entities;
using DiabetesMonitoringSystem.Infrastructure.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Memory;

namespace DiabetesMonitoringSystem.Persistence.Services
{
    public class ForgotPasswordService(IMailService mailService,IMemoryCache _cache,UserManager<AppUser> userManager) : IForgotPasswordService
    {
        public async Task<string> SendResetCode(string email)
        {
            var message = "";
            var emailExists = await userManager.FindByEmailAsync(email);
            if (emailExists == null)
            {
                message = "Bu e-posta adresiyle kayıtlı bir kullanıcı bulunamadı.";
                return(message);
            }

            var code = new Random().Next(100000, 999999).ToString(); // 6 haneli kod

            // cache'e 5 dakikalık kodu yaz
            _cache.Set(email, code, TimeSpan.FromMinutes(2));

            string htmlBody = $@"
                    <html>
                      <body style='font-family: Arial, sans-serif; font-size: 16px; color: #333;'>
                        <h2>Şifre Sıfırlama Kodu</h2>
                        <p>Şifre sıfırlamak için gerekli doğrulama kodunuz:</p>
                        <p style='font-size: 24px; font-weight: bold; color: #0078D7;'>{code}</p>
                        <p>⚠️ Bu kod sadece <strong>2 dakika</strong> geçerlidir.</p>
                        <br />
                        <hr />
                        <p style='font-size: 12px; color: #999;'>Eğer bu isteği siz yapmadıysanız, lütfen bu e-postayı dikkate almayın.</p>
                      </body>
                    </html>";

            await mailService.SendEmailAsync(email, "Şifre Sıfırlama Kodu",htmlBody,isHtml: true);
            message = "";
            return (message);
                
        }

        public async Task<bool> VerifyResetCode(string email, string verifyCode)
        {
            if (_cache.TryGetValue(email, out string? cachedCode))
            {
                if (cachedCode == verifyCode)
                {
                    _cache.Remove(email); // kod geçerliydi, bir daha kullanılmasın
                    return true;

                }
            }

            return false;
        }
    }
}
