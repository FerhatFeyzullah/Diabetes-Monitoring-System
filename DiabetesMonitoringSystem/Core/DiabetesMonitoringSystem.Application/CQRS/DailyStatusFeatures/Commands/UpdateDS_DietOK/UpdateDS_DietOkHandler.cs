using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiabetesMonitoringSystem.Application.Services;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.DailyStatusFeatures.Commands.UpdateDS_DietOK
{
    public class UpdateDS_DietOkHandler(IDS_Service dS_Service) : IRequestHandler<UpdateDS_DietOkRequest,Unit>
    {      

        async Task<Unit> IRequestHandler<UpdateDS_DietOkRequest, Unit>.Handle(UpdateDS_DietOkRequest request, CancellationToken cancellationToken)
        {
            await dS_Service.DietOk(request.DailyStatusId);
            return Unit.Value;
        }
    }
}
