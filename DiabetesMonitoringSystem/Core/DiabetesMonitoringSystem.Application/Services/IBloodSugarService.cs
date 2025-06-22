using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiabetesMonitoringSystem.Application.DTOs.BloodSugarDTOs;

namespace DiabetesMonitoringSystem.Application.Services
{
    public interface IBloodSugarService
    {
        Task<List<DailyBloodSugarGroupDto>> GetBloodSugarByPatientAndByDate(int patientId);
    }
}
