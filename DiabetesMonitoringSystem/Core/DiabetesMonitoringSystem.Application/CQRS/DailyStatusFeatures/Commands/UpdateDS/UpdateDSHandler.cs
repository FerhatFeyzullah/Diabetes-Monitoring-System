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

namespace DiabetesMonitoringSystem.Application.CQRS.DailyStatusFeatures.Commands.UpdateDS
{
    public class UpdateDSHandler(IWriteRepository<DailyStatus> writeRepository, IMapper mapper) : IRequestHandler<UpdateDSRequest, Unit>
    {
        public async Task<Unit> Handle(UpdateDSRequest request, CancellationToken cancellationToken)
        {
            var dailyStatus = mapper.Map<DailyStatus>(request);
            dailyStatus.Date = DateOnly.FromDateTime(DateTime.Today);
            await writeRepository.UpdateAsync(dailyStatus);
            return Unit.Value;
        }
    }
}
