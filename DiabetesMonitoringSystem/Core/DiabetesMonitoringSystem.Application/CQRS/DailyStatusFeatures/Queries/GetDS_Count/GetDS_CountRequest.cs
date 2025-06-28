using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.DailyStatusFeatures.Queries.GetDS_Count
{
    public class GetDS_CountRequest:IRequest<Unit>
    {
    }
}
