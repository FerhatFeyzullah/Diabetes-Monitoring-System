using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DiabetesMonitoringSystem.Application.Repositories;
using DiabetesMonitoringSystem.Domain.Entities;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.DailyStatusFeatures.Queries.GetDS_ByDate
{
    public class GetDS_ByDateHandler(IReadRepository<DailyStatus> readRepository,IMapper mapper) : IRequestHandler<GetDS_ByDateRequest, List<GetDS_ByDateResponse>>
    {
        public async Task<List<GetDS_ByDateResponse>> Handle(GetDS_ByDateRequest request, CancellationToken cancellationToken)
        {
            var values = await readRepository.GetByFilteredList(
                x => x.Date == request.Date,
                x => x.Patient
                );
            var mapped = mapper.Map<List<GetDS_ByDateResponse>>(values);
            return mapped;
        }
    }
}
