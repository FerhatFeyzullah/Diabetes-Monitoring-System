using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiabetesMonitoringSystem.Domain.Enums;

namespace DiabetesMonitoringSystem.Domain.Entities
{
    public class Alert
    {
        public int AlertId { get; set; }
        public DateOnly AlertDate { get; set; }        
        public AlertType AlertType { get; set; }
        public string Message { get; set; }
        public TimePeriod TimePeriod { get; set; }

        public int PatientId { get; set; }
        public AppUser Patient { get; set; }

        public int DoctorId { get; set; }

    }
}
