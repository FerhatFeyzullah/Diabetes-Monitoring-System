using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiabetesMonitoringSystem.Application.DTOs.InsulinDTOs;
using DiabetesMonitoringSystem.Domain.Enums;

namespace DiabetesMonitoringSystem.Application.Services
{
    public interface IInsulinService
    {
        Task<int> InsulinCreateBasedOnBloodSugar(TimePeriod timePeriod, int patientId,DateOnly date);
        Task<DailyInsulinGroupDto> GetInsulinByPatientAndGroupedByDateDaily(int patientId);
        Task<List<DailyInsulinGroupDto>> GetInsulinByPatientAndGroupedByDate(int patientId);
        Task<List<DailyInsulinGroupDto>> GetInsulinByPatientAndGroupedByFilteredDate(int patientId, DateOnly start, DateOnly end);
    }
}
