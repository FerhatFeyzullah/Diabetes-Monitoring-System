using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DiabetesMonitoringSystem.Application.Repositories;
using DiabetesMonitoringSystem.Domain.Entities;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.DailyStatusFeatures.Queries.GetDS_ByPatientAndDateDaily
{
    public class GetDS_ByPatientAndDateDailyHandler(IReadRepository<DailyStatus> readRepository,IMapper mapper) : IRequestHandler<GetDS_ByPatientAndDateDailyRequest, GetDS_ByPatientAndDateDailyResponse>
    {
        public async Task<GetDS_ByPatientAndDateDailyResponse> Handle(GetDS_ByPatientAndDateDailyRequest request, CancellationToken cancellationToken)
        {
            var value = await readRepository.GetByFiltered(
                x => x.PatientId == request.PatientId &&
                x.Date == DateOnly.FromDateTime(DateTime.Today)
                );
            return mapper.Map<GetDS_ByPatientAndDateDailyResponse>(value);
        }
    }
}
