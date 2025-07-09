using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.AlertFeatures.Queries.GetAlertsDaily
{
    public class GetAlertsDailyRequest:IRequest<List<GetAlertsDailyResponse>>
    {

    }
}
