using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DiabetesMonitoringSystem.Application.Repositories;
using DiabetesMonitoringSystem.Domain.Entities;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.DailyStatusFeatures.Queries.GetDS_ByPatientAndDate
{
    public class GetDS_ByPatientAndDateHandler(IReadRepository<DailyStatus> readRepository,IMapper mapper) : IRequestHandler<GetDS_ByPatientAndDateRequest, List<GetDS_ByPatientAndDateResponse>>
    {
        public async Task<List<GetDS_ByPatientAndDateResponse>> Handle(GetDS_ByPatientAndDateRequest request, CancellationToken cancellationToken)
        {
            var values = await readRepository.GetByFilteredList(x => x.PatientId == request.PatientId);         
            return mapper.Map<List<GetDS_ByPatientAndDateResponse>>(values);
        }
    }
}
