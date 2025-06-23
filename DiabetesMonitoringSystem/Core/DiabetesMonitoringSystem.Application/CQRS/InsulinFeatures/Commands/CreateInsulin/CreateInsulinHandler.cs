using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiabetesMonitoringSystem.Application.Services;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.InsulinFeatures.Commands.CreateInsulin
{
    public class CreateInsulinHandler(IInsulinService ınsulinService) : INotificationHandler<CreateInsulinNotification>
    {
        public async Task Handle(CreateInsulinNotification notification, CancellationToken cancellationToken)
        {
            var timePeriod = notification.TimePeriod;
            var patientId = notification.PatientId;
            var date = notification.Date;

            await ınsulinService.InsulinCreateBasedOnBloodSugar(timePeriod, patientId, date);           
        }
    }
}
