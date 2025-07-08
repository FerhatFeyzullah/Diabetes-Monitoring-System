using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiabetesMonitoringSystem.Domain.Enums;

namespace DiabetesMonitoringSystem.Application.Services
{
    public interface IPrescriptionService
    {
        Task CreatePrescriptionAsync(int patientId, int bsValue, List<string> symptoms, DateOnly date, TimePeriod timePeriod);


    }
}
