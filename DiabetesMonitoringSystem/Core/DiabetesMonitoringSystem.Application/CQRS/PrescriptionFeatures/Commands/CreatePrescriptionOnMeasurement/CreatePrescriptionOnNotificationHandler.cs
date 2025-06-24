using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiabetesMonitoringSystem.Application.Services;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.PrescriptionFeatures.Commands.CreatePrescriptionOnMeasurement
{
    public class CreatePrescriptionOnNotificationHandler(IPrescriptionService prescriptionService) : INotificationHandler<CreatePrescriptionNotification>
    {
        public async Task Handle(CreatePrescriptionNotification notification, CancellationToken cancellationToken)
        {
            await prescriptionService.CreatePrescriptionAsync
                (notification.PatientId,
                notification.BloodSugarValue,
                notification.Symptoms,
                notification.Date,
                notification.TimePeriod
                );
        }
    }
}
