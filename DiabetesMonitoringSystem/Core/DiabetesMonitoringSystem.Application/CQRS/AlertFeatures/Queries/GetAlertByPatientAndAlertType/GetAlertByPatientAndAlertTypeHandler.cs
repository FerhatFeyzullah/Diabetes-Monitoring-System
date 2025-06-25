using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DiabetesMonitoringSystem.Application.Repositories;
using DiabetesMonitoringSystem.Domain.Entities;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.AlertFeatures.Queries.GetAlertByPatientAndAlertType
{
    public class GetAlertByPatientAndAlertTypeHandler(IReadRepository<Alert> readRepository,IMapper mapper) : IRequestHandler<GetAlertByPatientAndAlertTypeRequest, List<GetAlertByPatientAndAlertTypeResponse>>
    {
        public async Task<List<GetAlertByPatientAndAlertTypeResponse>> Handle(GetAlertByPatientAndAlertTypeRequest request, CancellationToken cancellationToken)
        {
            var values = await readRepository.GetByFilteredList(
                x=>x.PatientId == request.PatientId &&
                x.AlertType == request.AlertType
                );
            return mapper.Map<List<GetAlertByPatientAndAlertTypeResponse>>(values);
        }
    }
}
