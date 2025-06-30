using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.InsulinFeatures.Queries.GetInsulinByPatientAndGroupedByDateDaily
{
    public class GetInsulinByPatientAndGroupedByDateDailyRequest:IRequest<GetInsulinByPatientAndGroupedByDateDailyResponse>
    {
        public int PatientId { get; set; }
    }
}
