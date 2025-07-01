using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabetesMonitoringSystem.Domain.Entities
{
    public class Prescription
    {
        public int PrescriptionId { get; set; }
        public DateOnly PrescriptionDate { get; set; }
        public List<string> Symptoms { get; set; }
        public string Diet { get; set; }
        public string Exercise { get; set; }
        public int PatientId { get; set; }
        public AppUser Patient { get; set; }

    }
}
