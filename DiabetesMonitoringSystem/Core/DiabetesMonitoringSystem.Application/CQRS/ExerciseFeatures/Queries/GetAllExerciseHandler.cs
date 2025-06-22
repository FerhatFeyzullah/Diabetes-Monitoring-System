using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DiabetesMonitoringSystem.Application.Repositories;
using DiabetesMonitoringSystem.Domain.Entities;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.ExerciseFeatures.Queries
{
    public class GetAllExerciseHandler(IReadRepository<Exercise> readRepository,IMapper mapper) : IRequestHandler<GetAllExerciseRequest, List<GetAllExerciseResponse>>
    {
        public async Task<List<GetAllExerciseResponse>> Handle(GetAllExerciseRequest request, CancellationToken cancellationToken)
        {
            var values = await readRepository.GetAllAsync();
            return mapper.Map<List<GetAllExerciseResponse>>(values);
        }
    }
}
