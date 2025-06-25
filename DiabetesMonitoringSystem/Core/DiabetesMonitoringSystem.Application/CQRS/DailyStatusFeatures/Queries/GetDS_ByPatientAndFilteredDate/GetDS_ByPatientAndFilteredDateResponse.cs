using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiabetesMonitoringSystem.Application.DTOs.UserDTOs;
using DiabetesMonitoringSystem.Domain.Entities;

namespace DiabetesMonitoringSystem.Application.CQRS.DailyStatusFeatures.Queries.GetDS_ByPatientAndFilteredDate
{
    public class GetDS_ByPatientAndFilteredDateResponse
    {
        public int DailyStatusId { get; set; }
        public DateOnly Date { get; set; }
        public bool ExerciseStatus { get; set; }
        public bool DietStatus { get; set; }
        public bool PrescriptionAvailable { get; set; }
    }
}
