using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DiabetesMonitoringSystem.Application.Services;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.BloodSugarFeatures.Queries.BloodSugarListByDate
{
    public class BloodSugarListByDateHandler(IBloodSugarService bloodSugarService,IMapper mapper) : IRequestHandler<BloodSugarListByDateRequest, List<BloodSugarListByDateResponse>>
    {
        public async Task<List<BloodSugarListByDateResponse>> Handle(BloodSugarListByDateRequest request, CancellationToken cancellationToken)
        {
            var values = await bloodSugarService.GetBloodSugarByPatientAndByDate(request.PatientId);
            var mapped = mapper.Map<List<BloodSugarListByDateResponse>>(values);
            return mapped;
        }
    }
}
