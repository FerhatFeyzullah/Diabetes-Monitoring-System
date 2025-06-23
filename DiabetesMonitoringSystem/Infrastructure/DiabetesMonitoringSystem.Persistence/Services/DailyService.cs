using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiabetesMonitoringSystem.Application.Services;
using DiabetesMonitoringSystem.Domain.Entities;
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

                if (exists) { continue; }

                var dailyStatus = new DailyStatus
                {
                    PatientId = patient.Id,
                    Date = today,
                    ExerciseStatus = false,
                    DietStatus = false
                };

                await _context.DailyStatuses.AddAsync(dailyStatus);
                await _context.SaveChangesAsync(ct);
            }
        }
    }
}
