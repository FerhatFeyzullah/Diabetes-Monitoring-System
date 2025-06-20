using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DiabetesMonitoringSystem.Application.Repositories;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.BloodSugar.Commands.AddBloodSugar
{
    public class AddBloodSugarHandler(IWriteRepository<Domain.Entities.BloodSugar> writeRepository,IMapper mapper) : IRequestHandler<AddBloodSugarRequest, Unit>
    {
        public Task<Unit> Handle(AddBloodSugarRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
