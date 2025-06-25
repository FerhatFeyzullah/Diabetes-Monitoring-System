using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DiabetesMonitoringSystem.Application.Services;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.BloodSugarFeatures.Queries.GetBS_ByPatientAndGroupedByFilteredDate
{
    public class GetBS_ByPatientAndGroupedByFilteredDateHandler(IBloodSugarService bloodSugarService,IMapper mapper) : IRequestHandler<GetBS_ByPatientAndGroupedByFilteredDateRequest, List<GetBS_ByPatientAndGroupedByFilteredDateResponse>>
    {
        public async Task<List<GetBS_ByPatientAndGroupedByFilteredDateResponse>> Handle(GetBS_ByPatientAndGroupedByFilteredDateRequest request, CancellationToken cancellationToken)
        {
            var values = await bloodSugarService.GetBloodSugarByPatientAndByFilteredDate(request.PatientId, request.StartDate, request.EndDate);
            return mapper.Map<List<GetBS_ByPatientAndGroupedByFilteredDateResponse>>(values);
        }
    }
}
