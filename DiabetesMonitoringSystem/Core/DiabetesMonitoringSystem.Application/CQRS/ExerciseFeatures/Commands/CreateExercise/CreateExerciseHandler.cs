using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DiabetesMonitoringSystem.Application.Repositories;
using DiabetesMonitoringSystem.Domain.Entities;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.ExerciseFeatures.Commands.CreateExercise
{
    public class CreateExerciseHandler(IWriteRepository<Exercise> writeRepository,IMapper mapper) : IRequestHandler<CreateExerciseRequest, Unit>
    {
        public async Task<Unit> Handle(CreateExerciseRequest request, CancellationToken cancellationToken)
        {
            var exercise = mapper.Map<Exercise>(request);
            await writeRepository.AddAsync(exercise);
            return Unit.Value;
        }
    }
}
