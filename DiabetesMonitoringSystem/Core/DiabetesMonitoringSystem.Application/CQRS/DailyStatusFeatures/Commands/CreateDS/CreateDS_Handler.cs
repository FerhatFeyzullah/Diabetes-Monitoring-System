using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DiabetesMonitoringSystem.Application.Repositories;
using DiabetesMonitoringSystem.Domain.Entities;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.DailyStatusFeatures.Commands.CreateDS
{
    public class CreateDS_Handler(IWriteRepository<DailyStatus> writeRepository,IMapper mapper) : IRequestHandler<CreateDS_Request, Unit>
    {
        public async Task<Unit> Handle(CreateDS_Request request, CancellationToken cancellationToken)
        {
            var dailyStatus = mapper.Map<DailyStatus>(request);
            dailyStatus.Date = DateOnly.FromDateTime(DateTime.Today);
            dailyStatus.DietStatus = false;
            dailyStatus.ExerciseStatus = false;
            await writeRepository.AddAsync(dailyStatus);
            return Unit.Value;
        }
    }
}
