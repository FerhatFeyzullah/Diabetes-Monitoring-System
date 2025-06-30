using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DiabetesMonitoringSystem.Application.Services;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.BloodSugarFeatures.Queries.GetBS_ByPatientAndGroupedByDateDaily
{
    public class GetBS_ByPatientAndGroupedByDateDailyHandler(IBloodSugarService bloodSugarService,IMapper mapper) : IRequestHandler<GetBS_ByPatientAndGroupedByDateDailyRequest, GetBS_ByPatientAndGroupedByDateDailyResponse>
    {
        public async Task<GetBS_ByPatientAndGroupedByDateDailyResponse> Handle(GetBS_ByPatientAndGroupedByDateDailyRequest request, CancellationToken cancellationToken)
        {
            var value = await bloodSugarService.GetBS_ByPatientAndGroupedByDateDaily(request.PatientId);
            return mapper.Map<GetBS_ByPatientAndGroupedByDateDailyResponse>(value);
        }
    }
}
