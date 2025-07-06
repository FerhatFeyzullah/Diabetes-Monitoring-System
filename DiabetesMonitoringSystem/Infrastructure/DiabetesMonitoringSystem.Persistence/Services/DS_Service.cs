using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiabetesMonitoringSystem.Application.Services;
using DiabetesMonitoringSystem.Persistence.DbContext;
using Microsoft.EntityFrameworkCore;

namespace DiabetesMonitoringSystem.Persistence.Services
{
    public class DS_Service : IDS_Service
    {
        private readonly DiabetesDbContext _dbContext;

        public DS_Service(DiabetesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task DietNotOk(int id)
        {
            var ds = await _dbContext.DailyStatuses.FindAsync(id);
            ds.DietStatus = false;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DietOk(int id)
        {
            var ds = await _dbContext.DailyStatuses.FindAsync(id);
            ds.DietStatus = true;
            await _dbContext.SaveChangesAsync();
        }

        public async Task ExerciseNotOk(int id)
        {
            var ds = await _dbContext.DailyStatuses.FindAsync(id);
            ds.ExerciseStatus = false;
            await _dbContext.SaveChangesAsync();
        }

        public async Task ExerciseOK(int id)
        {
            var ds = await _dbContext.DailyStatuses.FindAsync(id);               
            ds.ExerciseStatus = true;
            await _dbContext.SaveChangesAsync();
        }

        public async Task PrescriptionOk(int id, DateOnly date)
        {
            var ds = await _dbContext.DailyStatuses
                .Where(x => x.Date == date && x.PatientId == id)
                .FirstOrDefaultAsync();
            ds.PrescriptionAvailable = true;
            await _dbContext.SaveChangesAsync();
        }
    }
}
