using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DiabetesMonitoringSystem.Application.Services;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.InsulinFeatures.Queries.GetInsulinByPatientAndGroupedByDateDaily
{
    public class GetInsulinByPatientAndGroupedByDateDailyHandler(IInsulinService insulinService,IMapper mapper) : IRequestHandler<GetInsulinByPatientAndGroupedByDateDailyRequest, GetInsulinByPatientAndGroupedByDateDailyResponse>
    {
        public async Task<GetInsulinByPatientAndGroupedByDateDailyResponse> Handle(GetInsulinByPatientAndGroupedByDateDailyRequest request, CancellationToken cancellationToken)
        {
            var value = await insulinService.GetInsulinByPatientAndGroupedByDateDaily(request.PatientId);
            return mapper.Map<GetInsulinByPatientAndGroupedByDateDailyResponse>(value);
        }
    }
}
