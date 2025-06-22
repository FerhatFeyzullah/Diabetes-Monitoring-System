using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DiabetesMonitoringSystem.Application.Repositories;
using DiabetesMonitoringSystem.Domain.Entities;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.SymptomFeatures.Queries
{
    public class GetAllSymptomHandler(IReadRepository<Symptom> readRepository,IMapper mapper) : IRequestHandler<GetAllSymptomRequest, List<GetAllSymptomResponse>>
    {
        public async Task<List<GetAllSymptomResponse>> Handle(GetAllSymptomRequest request, CancellationToken cancellationToken)
        {
            var values = await readRepository.GetAllAsync();
            var mapped = mapper.Map<List<GetAllSymptomResponse>>(values);
            return mapped;
        }
    }
}
