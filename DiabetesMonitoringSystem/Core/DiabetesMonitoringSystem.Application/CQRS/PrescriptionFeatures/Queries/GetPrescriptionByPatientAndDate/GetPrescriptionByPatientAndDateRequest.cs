using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.PrescriptionFeatures.Queries.GetPrescriptionByPatientAndDate
{
    public class GetPrescriptionByPatientAndDateRequest:IRequest<List<GetPrescriptionByPatientAndDateResponse>>
    {
        public int PatientId { get; set; }
    }
}
