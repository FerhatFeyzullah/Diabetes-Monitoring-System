using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiabetesMonitoringSystem.Domain.Enums;

namespace DiabetesMonitoringSystem.Application.Services
{
    public interface IAlertService
    {
        Task GenerateAlertAsync(int patId, int bsValue, DateOnly date, TimePeriod period);
        Task<int> ReadingAlert(int AlertId, int doctorId);
    }
}
