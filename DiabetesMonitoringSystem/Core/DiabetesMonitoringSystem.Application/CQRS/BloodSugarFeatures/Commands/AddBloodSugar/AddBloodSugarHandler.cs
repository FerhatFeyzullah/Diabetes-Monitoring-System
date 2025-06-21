using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DiabetesMonitoringSystem.Application.Repositories;
using DiabetesMonitoringSystem.Domain.Entities;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.BloodSugarFeatures.Commands.AddBloodSugar
{
    public class AddBloodSugarHandler(IWriteRepository<BloodSugar> writeRepository,IMapper mapper) : IRequestHandler<AddBloodSugarRequest, Unit>
    {
        public async Task<Unit> Handle(AddBloodSugarRequest request, CancellationToken cancellationToken)
        {
            var bloodSugar = mapper.Map<BloodSugar>(request);
            await writeRepository.AddAsync(bloodSugar);
            return Unit.Value;
        }
    }
}
