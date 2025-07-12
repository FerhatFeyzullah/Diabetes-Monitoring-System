using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DiabetesMonitoringSystem.Application.Repositories;
using DiabetesMonitoringSystem.Domain.Entities;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.AlertFeatures.Queries.GetAlertsDaily
{
    public class GetAlertsDailyHandler(IReadRepository<Alert> readRepository,IMapper mapper) : IRequestHandler<GetAlertsDailyRequest, List<GetAlertsDailyResponse>>
    {
        public async Task<List<GetAlertsDailyResponse>> Handle(GetAlertsDailyRequest request, CancellationToken cancellationToken)
        {
            var values = await readRepository.GetByFilteredList(
                x => x.AlertDate == DateOnly.FromDateTime(DateTime.Today) &&
                x.DoctorId == request.DoctorId,
                x => x.Patient);               
            return mapper.Map<List<GetAlertsDailyResponse>>(values);
        }
    }
}
