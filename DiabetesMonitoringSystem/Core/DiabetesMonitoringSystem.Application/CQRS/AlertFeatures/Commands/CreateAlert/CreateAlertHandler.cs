using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiabetesMonitoringSystem.Application.Services;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.AlertFeatures.Commands.CreateAlert
{
    public class CreateAlertHandler(IAlertService alertService) : INotificationHandler<CreateAlertNotification>
    {
        public async Task Handle(CreateAlertNotification notification, CancellationToken cancellationToken)
        {
            var patId = notification.PatientId;
            var bsValue = notification.BloodSugarValue;
            var date = notification.Date;
            var period = notification.TimePeriod;

            await alertService.GenerateAlertAsync(patId, bsValue, date, period);
        }
    }
}
