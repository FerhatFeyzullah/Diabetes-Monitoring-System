using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.InsulinFeatures.Queries.GetInsulinByPatientAndGroupedByFilteredDate
{
    public class GetInsulinByPatientAndGroupedByFilteredDateRequest:IRequest<List<GetInsulinByPatientAndGroupedByFilteredDateResponse>>
    {
        public int PatientId { get; set; }
        public DateOnly Start { get; set; }
        public DateOnly End { get; set; }
    }
    
}
