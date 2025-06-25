using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DiabetesMonitoringSystem.Application.Repositories;
using DiabetesMonitoringSystem.Domain.Entities;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.AlertFeatures.Queries.GetAlertsByPatient
{
    public class GetAlertByPatientHandler(IReadRepository<Alert> readRepository,IMapper mapper) : IRequestHandler<GetAlertByPatientRequest, List<GetAlertByPatientResponse>>
    {
        public async Task<List<GetAlertByPatientResponse>> Handle(GetAlertByPatientRequest request, CancellationToken cancellationToken)
        {
            var values = await readRepository.GetByFilteredList(x => x.PatientId == request.PatientId);         
            return mapper.Map<List<GetAlertByPatientResponse>>(values);
             
        }
    }
}
