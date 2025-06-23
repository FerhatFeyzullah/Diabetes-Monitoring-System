using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DiabetesMonitoringSystem.Application.Repositories;
using DiabetesMonitoringSystem.Domain.Entities;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.DietFeatures.Queries.GetAllDiet
{
    public class GetAllDietHandler(IReadRepository<Diet> readRepository, IMapper mapper) : IRequestHandler<GetAllDietRequest, List<GetAllDietResponse>>
    {
        public async Task<List<GetAllDietResponse>> Handle(GetAllDietRequest request, CancellationToken cancellationToken)
        {
            var values = await readRepository.GetAllAsync();
            return mapper.Map<List<GetAllDietResponse>>(values);
        }
    }
}
