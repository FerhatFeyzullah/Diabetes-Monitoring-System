using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiabetesMonitoringSystem.Application.Services;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.DailyStatusFeatures.Commands.UpdateDS_ExerciseNotOk
{
    public class UpdateDS_ExerciseNotOkHandler(IDS_Service dS_Service) : IRequestHandler<UpdateDS_ExerciseNotOkRequest, Unit>
    {
        public async Task<Unit> Handle(UpdateDS_ExerciseNotOkRequest request, CancellationToken cancellationToken)
        {
            await dS_Service.ExerciseNotOk(request.DailyStatusId);
            return Unit.Value;
        }
    }
}
