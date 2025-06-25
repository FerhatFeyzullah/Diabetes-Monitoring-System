using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DiabetesMonitoringSystem.Application.Repositories;
using DiabetesMonitoringSystem.Domain.Entities;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.DailyStatusFeatures.Queries.GetDS_ByPatient
{
    public class GetDS_ByPatientHandler(IReadRepository<DailyStatus> readRepository,IMapper mapper) : IRequestHandler<GetDS_ByPatientRequest, List<GetDS_ByPatientResponse>>
    {
        public async Task<List<GetDS_ByPatientResponse>> Handle(GetDS_ByPatientRequest request, CancellationToken cancellationToken)
        {
            var values = await readRepository.GetByFilteredList(x => x.PatientId == request.PatientId);         
            return mapper.Map<List<GetDS_ByPatientResponse>>(values);
        }
    }
}
