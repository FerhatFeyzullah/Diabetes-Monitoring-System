using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DiabetesMonitoringSystem.Application.CQRS.DailyStatusFeatures.Queries.GetDS_ByPatient;
using DiabetesMonitoringSystem.Application.Repositories;
using DiabetesMonitoringSystem.Domain.Entities;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.DailyStatusFeatures.Queries.GetDS_ByPatientAndDate
{
    public class GetDS_ByPatientAndDateHandler(IReadRepository<DailyStatus> readRepository,IMapper mapper) : IRequestHandler<GetDS_ByPatientAndDateRequest, GetDS_ByPatientAndDateResponse>
    {
        public async Task<GetDS_ByPatientAndDateResponse> Handle(GetDS_ByPatientAndDateRequest request, CancellationToken cancellationToken)
        {
            var value = await readRepository.GetByFiltered(
                x => x.PatientId == request.PatientId &&
                x.Date == DateOnly.FromDateTime(DateTime.Today)
                );
            return mapper.Map<GetDS_ByPatientAndDateResponse>(value);
        }
    }
}
