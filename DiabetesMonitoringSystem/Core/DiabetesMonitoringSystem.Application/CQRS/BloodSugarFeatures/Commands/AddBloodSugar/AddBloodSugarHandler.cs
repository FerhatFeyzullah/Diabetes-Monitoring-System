﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DiabetesMonitoringSystem.Application.CQRS.AlertFeatures.Commands.CreateAlert;
using DiabetesMonitoringSystem.Application.CQRS.InsulinFeatures.Commands.CreateInsulin;
using DiabetesMonitoringSystem.Application.CQRS.PrescriptionFeatures.Commands.CreatePrescriptionOnMeasurement;
using DiabetesMonitoringSystem.Application.Repositories;
using DiabetesMonitoringSystem.Domain.Entities;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.BloodSugarFeatures.Commands.AddBloodSugar
{
    public class AddBloodSugarHandler(IWriteRepository<BloodSugar> writeRepository,IMapper mapper,IMediator mediator) : IRequestHandler<AddBloodSugarRequest, int>
    {
        public async Task<int> Handle(AddBloodSugarRequest request, CancellationToken cancellationToken)
        {
            var bloodSugar = mapper.Map<BloodSugar>(request);
            bloodSugar.MeasurementTime = DateOnly.FromDateTime(DateTime.Today);
            await writeRepository.AddAsync(bloodSugar);
            var dose = await mediator.Send(new CreateInsulinRequest {TimePeriod = bloodSugar.TimePeriod,PatientId =bloodSugar.PatientId, Date = bloodSugar.MeasurementTime });
            await mediator.Publish(new CreateAlertNotification { TimePeriod = bloodSugar.TimePeriod, PatientId = bloodSugar.PatientId,Date = bloodSugar.MeasurementTime,BloodSugarValue = bloodSugar.Value});
            await mediator.Publish(new CreatePrescriptionNotification 
            { PatientId = bloodSugar.PatientId,
                BloodSugarValue = bloodSugar.Value,
                Symptoms = bloodSugar.Symptoms,
                Date = bloodSugar.MeasurementTime,
                TimePeriod = bloodSugar.TimePeriod
            });
            return dose;
        }
    }
}
