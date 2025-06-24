using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiabetesMonitoringSystem.Domain.Enums;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.PrescriptionFeatures.Commands.CreatePrescriptionOnMeasurement
{
    public class CreatePrescriptionNotification:INotification
    {
        public TimePeriod TimePeriod { get; set; }
        public DateOnly Date { get; set; }
        public int PatientId { get; set; }
        public int BloodSugarValue { get; set; }
        public List<string> Symptoms { get; set; }
    }
}
