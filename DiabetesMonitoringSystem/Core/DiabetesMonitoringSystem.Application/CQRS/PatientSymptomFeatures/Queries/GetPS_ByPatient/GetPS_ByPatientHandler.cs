using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DiabetesMonitoringSystem.Application.Repositories;
using DiabetesMonitoringSystem.Domain.Entities;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.PatientSymptomFeatures.Queries.GetPS_ByPatient
{
    public class GetPS_ByPatientHandler(IReadRepository<PatientSymptom> readRepository,IMapper mapper) : IRequestHandler<GetPS_ByPatientRequest, List<GetPS_ByPatientResponse>>
    {
        public async Task<List<GetPS_ByPatientResponse>> Handle(GetPS_ByPatientRequest request, CancellationToken cancellationToken)
        {
            var values = await readRepository.GetByFilteredList(
                x => x.PatientId == request.PatientId,
                x => x.Symptom
                );

            return mapper.Map<List<GetPS_ByPatientResponse>>(values);
            
        }
    }
}
