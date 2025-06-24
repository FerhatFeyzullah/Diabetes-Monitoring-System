using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiabetesMonitoringSystem.Domain.Enums;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.AlertFeatures.Commands.CreateAlert
{
    public class CreateAlertNotification:INotification
    {
        public int PatientId { get; set; }
        public int BloodSugarValue { get; set; }
        public DateOnly Date { get; set; }
        public TimePeriod TimePeriod { get; set; }
    }
}
