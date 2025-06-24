using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using DiabetesMonitoringSystem.Infrastructure.Interfaces;
using MimeKit;
using MailKit.Net.Smtp;

namespace DiabetesMonitoringSystem.Infrastructure.Services
{
    public class MailService : IMailService
    {
        private readonly IConfiguration _configuration;

        public MailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string body, bool isHtml = false)
        {
            var email = new MimeMessage();
            email.From.Add(new MailboxAddress("Diyabet Takip Sistemi", _configuration["EmailSettings:SmtpUser"]));
            email.To.Add(new MailboxAddress("", toEmail));
            email.Subject = subject;
            email.Body = new TextPart(isHtml ? "html" : "plain")
            {
                Text = body
            };


            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                await client.AuthenticateAsync(_configuration["EmailSettings:SmtpUser"], _configuration["EmailSettings:SmtpPass"]);
                await client.SendAsync(email);
                await client.DisconnectAsync(true);
            }
        }
    }
}
