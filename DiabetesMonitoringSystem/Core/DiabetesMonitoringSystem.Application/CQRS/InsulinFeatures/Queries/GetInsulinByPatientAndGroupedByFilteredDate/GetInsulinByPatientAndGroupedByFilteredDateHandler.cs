using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DiabetesMonitoringSystem.Application.Services;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.InsulinFeatures.Queries.GetInsulinByPatientAndGroupedByFilteredDate
{
    public class GetInsulinByPatientAndGroupedByFilteredDateHandler(IInsulinService insulinService,IMapper mapper) : IRequestHandler<GetInsulinByPatientAndGroupedByFilteredDateRequest, List<GetInsulinByPatientAndGroupedByFilteredDateResponse>>
    {
        public async Task<List<GetInsulinByPatientAndGroupedByFilteredDateResponse>> Handle(GetInsulinByPatientAndGroupedByFilteredDateRequest request, CancellationToken cancellationToken)
        {
            var values = await insulinService.GetInsulinByPatientAndGroupedByFilteredDate(request.PatientId, request.Start, request.End);
            return mapper.Map<List<GetInsulinByPatientAndGroupedByFilteredDateResponse>>(values);
        }
    }
}
