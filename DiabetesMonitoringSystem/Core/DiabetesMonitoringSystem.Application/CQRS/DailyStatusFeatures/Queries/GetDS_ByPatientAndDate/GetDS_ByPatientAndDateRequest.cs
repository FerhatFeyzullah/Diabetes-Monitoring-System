using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.DailyStatusFeatures.Queries.GetDS_ByPatientAndDate
{
    public class GetDS_ByPatientAndDateRequest:IRequest<List<GetDS_ByPatientAndDateResponse>>
    {
        public int PatientId { get; set; }
       
    }
}
