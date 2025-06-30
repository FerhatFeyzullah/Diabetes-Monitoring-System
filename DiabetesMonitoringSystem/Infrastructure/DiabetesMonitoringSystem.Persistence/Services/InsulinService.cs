using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DiabetesMonitoringSystem.Application.DTOs.InsulinDTOs;
using DiabetesMonitoringSystem.Application.Repositories;
using DiabetesMonitoringSystem.Application.Services;
using DiabetesMonitoringSystem.Domain.Entities;
using DiabetesMonitoringSystem.Domain.Enums;
using DiabetesMonitoringSystem.Persistence.DbContext;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DiabetesMonitoringSystem.Persistence.Services
{
    public class InsulinService : IInsulinService
    {
        private readonly DiabetesDbContext _dbContext;
        

        public InsulinService(DiabetesDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task InsulinCreateBasedOnBloodSugar(TimePeriod timePeriod, int patientId, DateOnly date)
        {        
            var bloodSugars = await _dbContext.Set<BloodSugar>()
                .Where(x => x.PatientId == patientId && x.MeasurementTime == date)
                .ToListAsync();
            
            int insulinDose = CalculateInsulinDose(timePeriod, bloodSugars);
         
            var insulin = new Insulin
            {
                PatientId = patientId,
                Dose = insulinDose,
                Date = date,
                TimePeriod = timePeriod
            };
       
                await _dbContext.Insulins.AddAsync(insulin);     
                await _dbContext.SaveChangesAsync();

        }

        private int CalculateInsulinDose(TimePeriod timePeriod, List<BloodSugar> bloodSugars)
        {
            // Zaman dilimlerine göre kan şekeri değerlerini alma
            int morningValue = bloodSugars.FirstOrDefault(x => x.TimePeriod == TimePeriod.Morning)?.Value ?? 0;
            int middayValue = bloodSugars.FirstOrDefault(x => x.TimePeriod == TimePeriod.Midday)?.Value ?? 0;
            int afternoonValue = bloodSugars.FirstOrDefault(x => x.TimePeriod == TimePeriod.Afternoon)?.Value ?? 0;
            int eveningValue = bloodSugars.FirstOrDefault(x => x.TimePeriod == TimePeriod.Evening)?.Value ?? 0;
            int nightValue = bloodSugars.FirstOrDefault(x => x.TimePeriod == TimePeriod.Night)?.Value ?? 0;

            // Ortalama hesaplama
            int average = timePeriod switch
            {
                TimePeriod.Morning => morningValue,
                TimePeriod.Midday => CalculateAverage(new[] { morningValue, middayValue }),
                TimePeriod.Afternoon => CalculateAverage(new[] { morningValue, middayValue, afternoonValue }),
                TimePeriod.Evening => CalculateAverage(new[] { morningValue, middayValue, afternoonValue, eveningValue }),
                TimePeriod.Night => CalculateAverage(new[] { morningValue, middayValue, afternoonValue, eveningValue, nightValue }),
                _ => throw new ArgumentException("Geçersiz zaman dilimi.", nameof(timePeriod))
            };

            // İnsülin dozu hesaplama
            return average switch
            {
                < 70 => 0,
                >= 70 and <= 110 => 0,
                >= 111 and <= 150 => 1,
                >= 151 and <= 200 => 2,
                > 200 => 3,               
            };
        }

        private int CalculateAverage(int[] values)
        {
            var validValues = values.Where(v => v != 0).ToArray();
            return validValues.Length > 0 ? (int)validValues.Average() : 0;
        }

        public async Task<List<DailyInsulinGroupDto>> GetInsulinByPatientAndGroupedByDate(int patientId)
        {
            var values = await _dbContext.Insulins
                .Where(i=>i.PatientId == patientId)
                .GroupBy(i => i.Date)
                .Select(g=> new DailyInsulinGroupDto
                {
                    Date = g.Key,
                    Doses = g.Select(x => new InsulinDto
                    {
                        InsulinId = x.InsulinId,
                        Dose = x.Dose,
                        TimePeriod = x.TimePeriod
                    })
                    .OrderBy(h => h.TimePeriod)
                    .ToList()
                })
                .OrderBy(d => d.Date)
                .ToListAsync();
            return values;
        }

        public async Task<List<DailyInsulinGroupDto>> GetInsulinByPatientAndGroupedByFilteredDate(int patientId, DateOnly start, DateOnly end)
        {
            var values = await _dbContext.Insulins
                .Where(i => i.PatientId == patientId && i.Date >=start && i.Date<=end)
                .GroupBy(i => i.Date)
                .Select(g => new DailyInsulinGroupDto
                {
                    Date = g.Key,
                    Doses = g.Select(x => new InsulinDto
                    {
                        InsulinId = x.InsulinId,
                        Dose = x.Dose,
                        TimePeriod = x.TimePeriod
                    })
                    .OrderBy(h => h.TimePeriod)
                    .ToList()
                })
                .OrderBy(d => d.Date)
                .ToListAsync();
            return values;
        }

        public async Task<DailyInsulinGroupDto> GetInsulinByPatientAndGroupedByDateDaily(int patientId)
        {
            var date = DateOnly.FromDateTime(DateTime.Today);
            var value = await _dbContext.Insulins
                .Where(i => i.PatientId == patientId && i.Date == date)
                .GroupBy(i => i.Date)
                .Select(g => new DailyInsulinGroupDto
                {
                    Date = g.Key,
                    Doses = g.Select(x => new InsulinDto
                    {
                        InsulinId = x.InsulinId,
                        Dose = x.Dose,
                        TimePeriod = x.TimePeriod
                    })
                    .OrderBy(h => h.TimePeriod)
                    .ToList()
                })
                .OrderBy(d => d.Date)
                .FirstOrDefaultAsync();
            return value;
        }
    }
}

