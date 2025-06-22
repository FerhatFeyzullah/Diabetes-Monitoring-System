using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiabetesMonitoringSystem.Domain.Entities;

namespace DiabetesMonitoringSystem.Application.CQRS.DailyStatusFeatures.Queries.GetDS_ByPatient
{
    public class GetDS_ByPatientResponse
    {
        public int DailyStatusId { get; set; }

        public int PatientId { get; set; }

        public DateOnly Date { get; set; }

        public bool ExerciseStatus { get; set; }
        public bool DietStatus { get; set; }
    }
}
