using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiabetesMonitoringSystem.Application.Services;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.DailyStatusFeatures.Commands.UpdateDS_Diet
{
    public class UpdateDS_DietHandler(IDS_Service dS_Service) : IRequestHandler<UpdateDS_DietRequest,Unit>
    {      

        async Task<Unit> IRequestHandler<UpdateDS_DietRequest, Unit>.Handle(UpdateDS_DietRequest request, CancellationToken cancellationToken)
        {
            await dS_Service.DietOk(request.DailyStatusId);
            return Unit.Value;
        }
    }
}
