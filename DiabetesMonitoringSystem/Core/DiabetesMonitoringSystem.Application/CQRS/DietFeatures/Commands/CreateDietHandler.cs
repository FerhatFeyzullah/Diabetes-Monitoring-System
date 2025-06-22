using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DiabetesMonitoringSystem.Application.Repositories;
using DiabetesMonitoringSystem.Domain.Entities;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.DietFeatures.Commands
{
    public class CreateDietHandler(IWriteRepository<Diet> writeRepository, IMapper mapper) : IRequestHandler<CreateDietRequest, Unit>
    {
        public async Task<Unit> Handle(CreateDietRequest request, CancellationToken cancellationToken)
        {
            var diet = mapper.Map<Diet>(request);
            await writeRepository.AddAsync(diet);
            return Unit.Value;
        }
    }
}
