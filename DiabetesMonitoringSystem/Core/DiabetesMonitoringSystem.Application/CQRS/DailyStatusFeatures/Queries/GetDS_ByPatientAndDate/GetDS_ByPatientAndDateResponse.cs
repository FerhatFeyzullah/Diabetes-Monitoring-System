using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabetesMonitoringSystem.Application.CQRS.DailyStatusFeatures.Queries.GetDS_ByPatientAndDate
{
    public class GetDS_ByPatientAndDateResponse
    {
        public int DailyStatusId { get; set; }
        public DateOnly Date { get; set; }
        public bool ExerciseStatus { get; set; }
        public bool DietStatus { get; set; }
        public bool PrescriptionAvailable { get; set; }
    }
}
