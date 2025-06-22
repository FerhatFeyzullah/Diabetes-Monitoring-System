using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.DailyStatusFeatures.Queries.GetDS_ByDate
{
    public class GetDS_ByDateRequest:IRequest<List<GetDS_ByDateResponse>>
    {
        public DateOnly Date { get; set; }
    }
}
