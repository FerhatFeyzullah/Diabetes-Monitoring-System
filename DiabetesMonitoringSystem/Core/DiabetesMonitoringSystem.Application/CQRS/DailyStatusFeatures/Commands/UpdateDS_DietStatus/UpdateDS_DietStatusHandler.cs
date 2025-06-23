using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DiabetesMonitoringSystem.Application.Repositories;
using DiabetesMonitoringSystem.Application.Services;
using DiabetesMonitoringSystem.Domain.Entities;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.DailyStatusFeatures.Commands.UpdateDS_DietStatus
{
    public class UpdateDS_DietStatusHandler(IWriteRepository<DailyStatus> writeRepository, IMapper mapper) : IRequestHandler<UpdateDS_DietStatusRequest, Unit>
    {
        public async Task<Unit> Handle(UpdateDS_DietStatusRequest request, CancellationToken cancellationToken)
        {
            var dailyStatus = mapper.Map<DailyStatus>(request);
            dailyStatus.Date = DateOnly.FromDateTime(DateTime.Today);
            await writeRepository.UpdateAsync(dailyStatus);
            return Unit.Value;
        }
    }
}
