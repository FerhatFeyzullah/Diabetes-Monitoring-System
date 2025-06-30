using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.BloodSugarFeatures.Queries.GetBS_ByPatientAndGroupedByDateDaily
{
    public class GetBS_ByPatientAndGroupedByDateDailyRequest:IRequest<GetBS_ByPatientAndGroupedByDateDailyResponse>
    {
        public int PatientId { get; set; }
    }
}
