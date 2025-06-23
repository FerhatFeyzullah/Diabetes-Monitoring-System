using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DiabetesMonitoringSystem.Application.CQRS.InsulinFeatures.Commands.CreateInsulin;
using DiabetesMonitoringSystem.Application.Repositories;
using DiabetesMonitoringSystem.Domain.Entities;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.BloodSugarFeatures.Commands.AddBloodSugar
{
    public class AddBloodSugarHandler(IWriteRepository<BloodSugar> writeRepository,IMapper mapper,IMediator mediator) : IRequestHandler<AddBloodSugarRequest, Unit>
    {
        public async Task<Unit> Handle(AddBloodSugarRequest request, CancellationToken cancellationToken)
        {
            var bloodSugar = mapper.Map<BloodSugar>(request);
            bloodSugar.MeasurementTime = DateOnly.FromDateTime(DateTime.Today);
            await writeRepository.AddAsync(bloodSugar);
            await mediator.Publish(new CreateInsulinNotification {TimePeriod = bloodSugar.TimePeriod,PatientId =bloodSugar.PatientId, Date = bloodSugar.MeasurementTime });
            return Unit.Value;
        }
    }
}
