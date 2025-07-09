using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DiabetesMonitoringSystem.Application.CQRS.AlertFeatures.Queries.GetAlertsByPatientAndDate;
using DiabetesMonitoringSystem.Application.Repositories;
using DiabetesMonitoringSystem.Domain.Entities;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.AlertFeatures.Queries.GetAlertsByPatientAndDateAndType
{
    public class GetAlertsByPatientAndDateAndTypeHandler(IReadRepository<Alert> readRepository, IMapper mapper) : IRequestHandler<GetAlertsByPatientAndDateAndTypeRequest, List<GetAlertsByPatientAndDateAndTypeResponse>>
    {
        public async Task<List<GetAlertsByPatientAndDateAndTypeResponse>> Handle(GetAlertsByPatientAndDateAndTypeRequest request, CancellationToken cancellationToken)
        {
            var values = await readRepository.GetByFilteredList(
                x => x.PatientId == request.PatientId &&
                x.AlertDate >= request.StartDate &&
                x.AlertDate <= request.EndDate &&
                x.AlertType == request.AlertType
                );
            return mapper.Map<List<GetAlertsByPatientAndDateAndTypeResponse>>(values);
        }
    }
}
