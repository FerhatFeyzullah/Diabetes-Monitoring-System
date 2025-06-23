using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiabetesMonitoringSystem.Domain.Entities;

namespace DiabetesMonitoringSystem.Application.CQRS.PatientSymptomFeatures.Queries.GetPS_ByPatient
{
    public class GetPS_ByPatientResponse
    {
        public int PatientSymptomId { get; set; }

        public int SymptomId { get; set; }
        public Symptom Symptom { get; set; }

        public int PatientId { get; set; }     
        public DateOnly SymptomDate { get; set; }
    }
}
