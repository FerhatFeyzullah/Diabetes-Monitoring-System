using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DiabetesMonitoringSystem.Application.Repositories;
using DiabetesMonitoringSystem.Domain.Entities;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.PrescriptionFeatures.Commands.UpdatePrescription
{
    public class UpdatePrescriptionHandler(IWriteRepository<Prescription> writeRepository,IMapper mapper) : IRequestHandler<UpdatePrescriptionRequest, Unit>
    {
        public async Task<Unit> Handle(UpdatePrescriptionRequest request, CancellationToken cancellationToken)
        {
            var prescription = mapper.Map<Prescription>(request);
            prescription.PrescriptionDate = DateOnly.FromDateTime(DateTime.Today);
            await writeRepository.UpdateAsync(prescription);
            return Unit.Value;
        }
    }
}
