using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiabetesMonitoringSystem.Domain.Enums;

namespace DiabetesMonitoringSystem.Domain.Entities
{
 
    public class BloodSugar
    {
        public int BloodSugarId { get; set; }
        public int Value { get; set; }
        public DateTime MeasurementTime { get; set; }
        public TimePeriod TimePeriod { get; set; }

        public int PatientId { get; set; }
        public AppUser Patient { get; set; }

    }
}
