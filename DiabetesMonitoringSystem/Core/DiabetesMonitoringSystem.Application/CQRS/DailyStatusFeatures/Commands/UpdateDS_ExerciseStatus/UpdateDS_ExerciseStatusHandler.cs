using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DiabetesMonitoringSystem.Application.Repositories;
using DiabetesMonitoringSystem.Domain.Entities;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.DailyStatusFeatures.Commands.UpdateDS_ExerciseStatus
{
    public class UpdateDS_ExerciseStatusHandler(IWriteRepository<DailyStatus> writeRepository,IMapper mapper) : IRequestHandler<UpdateDS_ExerciseStatusRequest, Unit>
    {
        public async Task<Unit> Handle(UpdateDS_ExerciseStatusRequest request, CancellationToken cancellationToken)
        {
            var dailyStatus = mapper.Map<DailyStatus>(request);
            await writeRepository.UpdateAsync(dailyStatus);
            return Unit.Value;
        }
    }
}
