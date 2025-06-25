using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DiabetesMonitoringSystem.Application.DTOs.BloodSugarDTOs;
using DiabetesMonitoringSystem.Application.Services;
using DiabetesMonitoringSystem.Persistence.DbContext;
using Microsoft.EntityFrameworkCore;

namespace DiabetesMonitoringSystem.Persistence.Services
{
    public class BloodSugarService : IBloodSugarService
    {

        private readonly DiabetesDbContext _dbContext;
        public BloodSugarService(DiabetesDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;          
        }

        public async Task<List<DailyBloodSugarGroupDto>> GetBloodSugarByPatientAndByDate(int patientId)
        {
            var values = await _dbContext.BloodSugars
                .Where(b => b.PatientId == patientId)
                .GroupBy(b => b.MeasurementTime)
                .Select(g => new DailyBloodSugarGroupDto
                {
                    MeasurementTime = g.Key,
                    Measurements = g.Select(x => new BloodSugarDto
                    {
                        BloodSugarId = x.BloodSugarId,
                        Value = x.Value,
                        TimePeriod = x.TimePeriod
                    })
                    .OrderBy(h => h.TimePeriod)
                    .ToList()
                })
                .OrderBy(d => d.MeasurementTime)
                .ToListAsync();
            return values;
        }

        public async Task<List<DailyBloodSugarGroupDto>> GetBloodSugarByPatientAndByFilteredDate(int patientId, DateOnly start, DateOnly end)
        {
            var values = await _dbContext.BloodSugars
                 .Where(b => b.PatientId == patientId && b.MeasurementTime >= start && b.MeasurementTime <=end)
                 .GroupBy(b => b.MeasurementTime)
                 .Select(g => new DailyBloodSugarGroupDto
                 {
                     MeasurementTime = g.Key,
                     Measurements = g.Select(x => new BloodSugarDto
                     {
                         BloodSugarId = x.BloodSugarId,
                         Value = x.Value,
                         TimePeriod = x.TimePeriod
                     })
                     .OrderBy(h => h.TimePeriod)
                     .ToList()
                 })
                 .OrderBy(d => d.MeasurementTime)
                 .ToListAsync();
            return values;
        }
    }
}
