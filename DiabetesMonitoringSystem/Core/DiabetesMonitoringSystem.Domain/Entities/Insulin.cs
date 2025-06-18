using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiabetesMonitoringSystem.Domain.Enums;

namespace DiabetesMonitoringSystem.Domain.Entities
{
    public class Insulin
    {
        public int InsulinId { get; set; }
        public int Dose { get; set; }
        public TimePeriod TimePeriod { get; set; }

        public int PatientId { get; set; }
        public AppUser Patient { get; set; }

    }
}
