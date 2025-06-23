using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.DailyStatusFeatures.Commands.CreateDS_OnPrescriptionCreate
{
    public class PrescriptionCreated:INotification
    {
        public int PatientId { get; set; }      
    }
}
