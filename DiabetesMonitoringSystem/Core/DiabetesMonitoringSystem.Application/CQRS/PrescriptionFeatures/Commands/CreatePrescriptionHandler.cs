using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DiabetesMonitoringSystem.Application.Repositories;
using DiabetesMonitoringSystem.Domain.Entities;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.PrescriptionFeatures.Commands
{
    public class CreatePrescriptionHandler(IWriteRepository<Prescription> writeRepository,IMapper mapper) : IRequestHandler<CreatePrescriptionRequest, Unit>
    {
        public async Task<Unit> Handle(CreatePrescriptionRequest request, CancellationToken cancellationToken)
        {
            var prescription = mapper.Map<Prescription>(request);
            await writeRepository.AddAsync(prescription);
            return Unit.Value;
        }
    }
}
