using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiabetesMonitoringSystem.Application.Services;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.DailyStatusFeatures.Commands.UpdateDS_ExerciseOk
{
    public class UpdateDS_ExerciseOkHandler(IDS_Service dS_Service) : IRequestHandler<UpdateDS_ExerciseOkRequest, Unit>
    {
        public async Task<Unit> Handle(UpdateDS_ExerciseOkRequest request, CancellationToken cancellationToken)
        {
            await dS_Service.ExerciseOK(request.DailyStatusId);
            return Unit.Value; 
        }
    }
}
