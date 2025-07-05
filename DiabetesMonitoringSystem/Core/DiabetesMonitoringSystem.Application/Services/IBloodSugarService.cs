using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiabetesMonitoringSystem.Application.DTOs.BloodSugarDTOs;
using DiabetesMonitoringSystem.Domain.Enums;

namespace DiabetesMonitoringSystem.Application.Services
{
    public interface IBloodSugarService
    {
        Task<DailyBloodSugarGroupDto> GetBS_ByPatientAndGroupedByDateDaily(int patientId);
        Task<List<DailyBloodSugarGroupDto>> GetBloodSugarByPatientAndByDate(int patientId);
        Task<List<DailyBloodSugarGroupDto>> GetBloodSugarByPatientAndByFilteredDate(int patientId,DateOnly start,DateOnly end);
        Task<bool> GetBS_TimePeriodCheck(int patientId,TimePeriod timePeriod);
    }
}
