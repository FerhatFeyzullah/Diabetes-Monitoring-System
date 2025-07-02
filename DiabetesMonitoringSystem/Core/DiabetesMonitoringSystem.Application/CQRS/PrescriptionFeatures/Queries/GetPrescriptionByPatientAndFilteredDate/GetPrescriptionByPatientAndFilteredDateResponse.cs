using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiabetesMonitoringSystem.Domain.Entities;

namespace DiabetesMonitoringSystem.Application.CQRS.PrescriptionFeatures.Queries.GetPrescriptionByPatientAndFilteredDate
{
    public class GetPrescriptionByPatientAndFilteredDateResponse
    {
        public int PrescriptionId { get; set; }
        public DateOnly PrescriptionDate { get; set; }
        public string Diet { get; set; }
        public string Exercise { get; set; }
        public int PatientId { get; set; }
        public List<string> Symptoms { get; set; }

    }
}
