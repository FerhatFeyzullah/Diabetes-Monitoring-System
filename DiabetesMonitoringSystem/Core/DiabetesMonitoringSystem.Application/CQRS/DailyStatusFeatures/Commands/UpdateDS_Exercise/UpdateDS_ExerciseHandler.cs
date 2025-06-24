using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiabetesMonitoringSystem.Application.Services;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.DailyStatusFeatures.Commands.UpdateDS_Exercise
{
    public class UpdateDS_ExerciseHandler(IDS_Service dS_Service) : IRequestHandler<UpdateDS_ExerciseRequest, Unit>
    {
        public async Task<Unit> Handle(UpdateDS_ExerciseRequest request, CancellationToken cancellationToken)
        {
            await dS_Service.ExerciseOK(request.DailyStatusId);
            return Unit.Value; 
        }
    }
}
