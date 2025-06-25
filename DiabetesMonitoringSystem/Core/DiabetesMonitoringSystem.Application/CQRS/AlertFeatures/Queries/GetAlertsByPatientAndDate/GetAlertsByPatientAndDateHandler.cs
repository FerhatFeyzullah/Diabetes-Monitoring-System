using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DiabetesMonitoringSystem.Application.Repositories;
using DiabetesMonitoringSystem.Domain.Entities;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.AlertFeatures.Queries.GetAlertsByPatientAndDate
{
    public class GetAlertsByPatientAndDateHandler(IReadRepository<Alert> readRepository,IMapper mapper) : IRequestHandler<GetAlertsByPatientAndDateRequest, List<GetAlertsByPatientAndDateResponse>>
    {
        public async Task<List<GetAlertsByPatientAndDateResponse>> Handle(GetAlertsByPatientAndDateRequest request, CancellationToken cancellationToken)
        {
            var values = await readRepository.GetByFilteredList(
                x=>x.PatientId == request.PatientId &&
                x.AlertDate >= request.StartDate &&
                x.AlertDate <= request.EndDate
                );
            return mapper.Map<List<GetAlertsByPatientAndDateResponse>>(values);
        }
    }
}
