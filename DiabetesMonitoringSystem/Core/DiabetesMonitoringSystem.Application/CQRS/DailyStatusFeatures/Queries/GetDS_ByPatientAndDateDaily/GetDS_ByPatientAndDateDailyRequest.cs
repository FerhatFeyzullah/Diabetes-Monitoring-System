using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.DailyStatusFeatures.Queries.GetDS_ByPatientAndDateDaily
{
    public class GetDS_ByPatientAndDateDailyRequest:IRequest<GetDS_ByPatientAndDateDailyResponse>
    {
        public int PatientId { get; set; }
    }
}
