using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiabetesMonitoringSystem.Application.Services;
using DiabetesMonitoringSystem.Domain.Entities;
using DiabetesMonitoringSystem.Domain.Enums;
using DiabetesMonitoringSystem.Infrastructure.Interfaces;
using DiabetesMonitoringSystem.Persistence.DbContext;
using Microsoft.EntityFrameworkCore;

namespace DiabetesMonitoringSystem.Persistence.Services
{
    public class AlertService : IAlertService
    {
        private readonly DiabetesDbContext _dbContext;
        private readonly IMailService _mailService;

        public AlertService(DiabetesDbContext dbContext, IMailService mailService)
        {
            _dbContext = dbContext;
            _mailService = mailService;
        }

        public async Task GenerateAlertAsync(int patId, int bsValue, DateOnly date, TimePeriod period)
        {
            var doctorId = await _dbContext.Users
                .Where(p => p.Id == patId)
                .Select(p => p.DoctorId)
                .FirstOrDefaultAsync();

            var (alertType, message) = GetAlertDetails(bsValue);
            if (alertType == null)
                return;

            var alert = new Alert
            {
                PatientId = patId,
                DoctorId = doctorId??0,
                AlertType = alertType.Value,
                Message = message,
                AlertDate = date,
                TimePeriod = period
            };

            await _dbContext.Alerts.AddAsync(alert);
            await _dbContext.SaveChangesAsync();

            if (alert.AlertType == AlertType.Emergency)
            { 
                await SendMail(doctorId.Value,patId,message);
            }
            
        }

        private async Task SendMail(int docId,int patId,string message)
        {
            var email = await _dbContext.Users
                .Where(u => u.Id == docId)
                .Select(u => u.Email)
                .FirstOrDefaultAsync();
            var patientFullName = await _dbContext.Users
                .Where(u => u.Id == patId)
                .Select(u => $"{u.FirstName} {u.LastName}")
                .FirstOrDefaultAsync();

            string htmlBody = $@"
        <div style='font-family: Arial, sans-serif; padding: 20px; color: #333;'>
            <h2 style='color: #d9534f;'>📢 Diyabet Takip Uyarısı</h2>
            <p><strong>Hasta:</strong> {patientFullName}</p>
            <p><strong>Uyarı Mesajı:</strong></p>
            <div style='background-color: #f8d7da; border-left: 6px solid #d9534f; padding: 10px; margin: 10px 0;'>
                {message}
            </div>
            <p>Lütfen hastanın durumu hakkında gerekli önlemleri alınız.</p>
            <hr />
            <p style='font-size: 12px; color: #999;'>Bu e-posta Diyabet Takip Sistemi tarafından otomatik olarak gönderilmiştir.</p>
        </div>";

            await _mailService.SendEmailAsync(email, "📢 Diyabet Takip Uyarısı", htmlBody, isHtml: true);

        }
        private (AlertType? alertType, string message) GetAlertDetails(int bloodSugarValue)
        {
            return bloodSugarValue switch
            {
                < 70 => (AlertType.Emergency, "Hastanın kan şekeri seviyesi 70 mg/dL’nin altına düştü. Hipoglisemi riski! Hızlı müdahale gerekebilir."),
                >= 70 and <= 110 => (null, "Kan şekeri seviyesi normal aralıkta. Hiçbir işlem gerekmez."),
                >= 111 and <= 150 => (AlertType.FollowUp, "Hastanın kan şekeri 111-150 mg/dL arasında. Durum izlenmeli."),
                >= 151 and <= 200 => (AlertType.Monitoring, "Hastanın kan şekeri 151-200 mg/dL arasında. Diyabet kontrolü gereklidir."),
                > 200 => (AlertType.Emergency, "Hastanın kan şekeri 200 mg/dL’nin üzerinde. Hiperglisemi durumu. Acil müdahale gerekebilir."),               
            };
        }
    }
}
