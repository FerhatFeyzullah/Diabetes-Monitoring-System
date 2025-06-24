using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiabetesMonitoringSystem.Application.Services;
using DiabetesMonitoringSystem.Domain.Entities;
using DiabetesMonitoringSystem.Domain.Enums;
using DiabetesMonitoringSystem.Persistence.DbContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DiabetesMonitoringSystem.Persistence.Services
{
    public class DailyService
    {
        private readonly DiabetesDbContext _context;
        private readonly UserManager<AppUser> userManager;

        public DailyService(DiabetesDbContext context,UserManager<AppUser> userManager)
        {
            _context = context;
            this.userManager = userManager;
        }

       
        public async Task DailyCreateDS_Async(CancellationToken ct = default)
        {
            var today = DateOnly.FromDateTime(DateTime.Now.Date);

            var patients = userManager.GetUsersInRoleAsync("Hasta").Result;

            foreach (var patient in patients)
            {
                bool exists = await _context.DailyStatuses
                    .AsNoTracking()
                    .AnyAsync(x => x.PatientId == patient.Id && x.Date == today, ct);

                bool prescriptionAvailable = await _context.Prescriptions
                    .AsNoTracking()
                    .AnyAsync(x => x.PatientId == patient.Id && x.PrescriptionDate == today, ct);

                if (exists) { continue; }

                var dailyStatus = new DailyStatus
                {
                    PatientId = patient.Id,
                    Date = today,
                    ExerciseStatus = false,
                    DietStatus = false,
                    PrescriptionAvailable = prescriptionAvailable,
                };

                await _context.DailyStatuses.AddAsync(dailyStatus);
                await _context.SaveChangesAsync(ct);
            }
        }

        public async Task CheckDailyMeasurementsAsync(CancellationToken cancellationToken)
        {
            var today = DateOnly.FromDateTime(DateTime.Today);
            var patients = await _context.Users
                .Select(p => new { p.Id, p.DoctorId })
                .ToListAsync(cancellationToken);

            using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
            try
            {
                foreach (var patient in patients)
                {
                    var measurementCount = await _context.BloodSugars
                        .CountAsync(bs => bs.PatientId == patient.Id && bs.MeasurementTime == today, cancellationToken);

                    Alert alert = null;
                    if (measurementCount == 0)
                    {
                        alert = new Alert
                        {
                            PatientId = patient.Id,
                            DoctorId = patient.DoctorId ?? 0,
                            AlertType = AlertType.MissingMeasurement,
                            Message = "Hasta gün boyunca kan şekeri ölçümü yapmamıştır. Acil takip önerilir.",
                            AlertDate = DateOnly.FromDateTime(DateTime.Today),
                        };
                    }
                    else if (measurementCount < 3)
                    {
                        alert = new Alert
                        {
                            PatientId = patient.Id,
                            DoctorId = patient.DoctorId ?? 0,
                            AlertType = AlertType.InsufficientMeasurement,
                            Message = "Hastanın günlük kan şekeri ölçüm sayısı yetersiz. Durum izlenmelidir.",
                            AlertDate = DateOnly.FromDateTime(DateTime.Today)
                        };
                    }

                    if (alert != null)
                    {
                        await _context.Alerts.AddAsync(alert, cancellationToken);
                    }
                }

                await _context.SaveChangesAsync(cancellationToken);
                await transaction.CommitAsync(cancellationToken);

            }
            catch
            {
                await transaction.RollbackAsync(cancellationToken);
                throw;
            }
        }
    }
}
