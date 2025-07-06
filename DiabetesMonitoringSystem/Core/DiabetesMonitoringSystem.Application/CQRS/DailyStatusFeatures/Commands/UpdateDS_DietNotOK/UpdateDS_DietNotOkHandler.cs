using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiabetesMonitoringSystem.Application.Services;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.DailyStatusFeatures.Commands.UpdateDS_DietNotOK
{
    public class UpdateDS_DietNotOkHandler(IDS_Service dS_Service) : IRequestHandler<UpdateDS_DietNotOkRequest, Unit>
    {
        public async Task<Unit> Handle(UpdateDS_DietNotOkRequest request, CancellationToken cancellationToken)
        {
            await dS_Service.DietNotOk(request.DailyStatusId);
            return Unit.Value;
        }
    }
}
