using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DiabetesMonitoringSystem.Application.CQRS.InsulinFeatures.Queries.GetInsulinByPatientAndGroupedByFilteredDate;
using DiabetesMonitoringSystem.Application.Repositories;
using DiabetesMonitoringSystem.Application.Services;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.InsulinFeatures.Queries.GetInsulinByPatientAndGroupedByDate
{
    public class GetInsulinByPatientAndGroupedByDateHandler(IInsulinService insulinService,IMapper mapper) : IRequestHandler<GetInsulinByPatientAndGroupedByDateRequest, List<GetInsulinByPatientAndGroupedByDateResponse>>
    {
        public async Task<List<GetInsulinByPatientAndGroupedByDateResponse>> Handle(GetInsulinByPatientAndGroupedByDateRequest request, CancellationToken cancellationToken)
        {
            var values = await insulinService.GetInsulinByPatientAndGroupedByDate(request.PatientId);
            return mapper.Map<List<GetInsulinByPatientAndGroupedByDateResponse>>(values);
        }
    }
}
