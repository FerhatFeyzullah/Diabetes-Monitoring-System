using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiabetesMonitoringSystem.Domain.Entities;

namespace DiabetesMonitoringSystem.Application.CQRS.PrescriptionFeatures.Queries.GetPrescriptionByPatientAndDate
{
    public class GetPrescriptionByPatientAndDateResponse
    {
        public int PrescriptionId { get; set; }
        public DateOnly PrescriptionDate { get; set; }
        public int DietId { get; set; }
        public Diet Diet { get; set; }
        public int ExerciseId { get; set; }
        public Exercise Exercise { get; set; }
        public int PatientId { get; set; }
    }
}
