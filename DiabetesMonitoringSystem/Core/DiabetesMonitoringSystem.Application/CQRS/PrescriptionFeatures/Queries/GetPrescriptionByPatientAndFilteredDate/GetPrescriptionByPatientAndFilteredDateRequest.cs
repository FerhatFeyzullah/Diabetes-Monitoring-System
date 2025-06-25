using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.PrescriptionFeatures.Queries.GetPrescriptionByPatientAndFilteredDate
{
    public class GetPrescriptionByPatientAndFilteredDateRequest:IRequest<List<GetPrescriptionByPatientAndFilteredDateResponse>>
    {
        public int PatientId { get; set; }
        public DateOnly Start { get; set; }
        public DateOnly End { get; set; }
    }
    
}
