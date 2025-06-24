using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiabetesMonitoringSystem.Domain.Enums;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.BloodSugarFeatures.Commands.AddBloodSugar
{
    public class AddBloodSugarRequest:IRequest<Unit>
    {
        public int Value { get; set; }
        public TimePeriod TimePeriod { get; set; }
        public List<string>? Symptoms { get; set; }

        public int PatientId { get; set; }
    }
}
