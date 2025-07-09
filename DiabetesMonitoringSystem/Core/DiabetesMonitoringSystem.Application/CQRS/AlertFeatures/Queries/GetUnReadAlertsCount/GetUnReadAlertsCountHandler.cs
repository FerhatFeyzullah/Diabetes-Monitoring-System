using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiabetesMonitoringSystem.Application.Repositories;
using DiabetesMonitoringSystem.Domain.Entities;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.AlertFeatures.Queries.GetUnReadAlertsCount
{
    public class GetUnReadAlertsCountHandler(IReadRepository<Alert> readRepository) : IRequestHandler<GetUnReadAlertsCountRequest, int>
    {
        public async Task<int> Handle(GetUnReadAlertsCountRequest request, CancellationToken cancellationToken)
        {
            var count = await readRepository.FilteredCountAsync(
                x => x.DoctorId == request.DoctorId &&
                x.AlertDate == DateOnly.FromDateTime(DateTime.Today)&&
                x.IsRead == false
            );
            return count;
        }
    }
}
