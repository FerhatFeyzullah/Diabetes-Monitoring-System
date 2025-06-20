using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabetesMonitoringSystem.Domain.Entities
{
    public class PatientSymptom
    {
        public int PatientSymptomId { get; set; }

        public int SymptomId { get; set; }
        public Symptom Symptom { get; set; }

        public int PatientId { get; set; }
        public AppUser Patient { get; set; }

        public DateTime SymptomDate { get; set; } = DateTime.Now;

    }
}
