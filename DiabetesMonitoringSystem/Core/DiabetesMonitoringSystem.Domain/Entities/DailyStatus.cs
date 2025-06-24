using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabetesMonitoringSystem.Domain.Entities
{
    public class DailyStatus
    {
        public int DailyStatusId { get; set; }

        public int PatientId { get; set; }
        public AppUser Patient { get; set; }

        public DateOnly Date { get; set; }

        public bool PrescriptionAvailable { get; set; }
        public bool ExerciseStatus { get; set; }
        public bool DietStatus { get; set; }

    }
}
