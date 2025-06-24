using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabetesMonitoringSystem.Application.Services
{
    public interface IDS_Service
    {
        Task DietOk(int id);
        Task ExerciseOK(int id);
        Task PrescriptionOk(int id, DateOnly date);
    }
}
