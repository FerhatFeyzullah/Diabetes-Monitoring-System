using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DiabetesMonitoringSystem.Application.Repositories;
using DiabetesMonitoringSystem.Domain.Entities;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.User.Queries.GetPatientWithDoctor
{
    public class GetPatientForDoctorHandler(IReadRepository<AppUser> readRepository,IMapper mapper) : IRequestHandler<GetPatientForDoctorRequest, List<GetPatientForDoctorResponse>>
    {
        public async Task<List<GetPatientForDoctorResponse>> Handle(GetPatientForDoctorRequest request, CancellationToken cancellationToken)
        {
            var values = await readRepository.GetByFilteredList(x => x.DoctorId == request.DoctorId);
            return mapper.Map<List<GetPatientForDoctorResponse>>(values);            
        }
    }
}
