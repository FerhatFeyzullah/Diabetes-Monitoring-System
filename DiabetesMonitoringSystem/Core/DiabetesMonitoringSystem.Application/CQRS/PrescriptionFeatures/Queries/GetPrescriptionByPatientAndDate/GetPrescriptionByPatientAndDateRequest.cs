using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.PrescriptionFeatures.Queries.GetPrescriptionByPatientAndDate
{
    public class GetPrescriptionByPatientAndDateRequest:IRequest<GetPrescriptionByPatientAndDateResponse>
    {
        public int PatientId { get; set; }
    }
}
