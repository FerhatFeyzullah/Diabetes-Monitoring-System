using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.DailyStatusFeatures.Queries.GetDS_ByPatientAndFilteredDate
{
    public class GetDS_ByPatientAndFilteredDateRequest:IRequest<List<GetDS_ByPatientAndFilteredDateResponse>>
    {
        public int PatientId { get; set; }
        public DateOnly Start { get; set; }
        public DateOnly End { get; set; }
    }
}
