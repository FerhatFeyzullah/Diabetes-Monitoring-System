using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DiabetesMonitoringSystem.Application.Repositories;
using DiabetesMonitoringSystem.Domain.Entities;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.DailyStatusFeatures.Queries.GetDS_ByPatientAndFilteredDate
{
    public class GetDS_ByPatientAndFilteredDateHandler(IReadRepository<DailyStatus> readRepository,IMapper mapper) : IRequestHandler<GetDS_ByPatientAndFilteredDateRequest, List<GetDS_ByPatientAndFilteredDateResponse>>
    {
        public async Task<List<GetDS_ByPatientAndFilteredDateResponse>> Handle(GetDS_ByPatientAndFilteredDateRequest request, CancellationToken cancellationToken)
        {
            var values = await readRepository.GetByFilteredList(
                x =>x.PatientId == request.PatientId &&
                x.Date >= request.Start && x.Date <= request.End
                );
            return mapper.Map<List<GetDS_ByPatientAndFilteredDateResponse>>(values);
        }
    }
}
