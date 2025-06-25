using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.PrescriptionFeatures.Queries.GetPrescriptionByPatient
{
    public class GetPrescriptionByPatientRequest:IRequest<List<GetPrescriptionByPatientResponse>>
    {
        public int PatientId { get; set; }
    }
}
