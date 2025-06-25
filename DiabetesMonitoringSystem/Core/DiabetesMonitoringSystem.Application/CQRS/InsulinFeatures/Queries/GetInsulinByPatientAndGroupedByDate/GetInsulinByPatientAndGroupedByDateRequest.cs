using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.InsulinFeatures.Queries.GetInsulinByPatientAndGroupedByDate
{
    public class GetInsulinByPatientAndGroupedByDateRequest:IRequest<List<GetInsulinByPatientAndGroupedByDateResponse>>
    {
        public int PatientId { get; set; }
    }
}
