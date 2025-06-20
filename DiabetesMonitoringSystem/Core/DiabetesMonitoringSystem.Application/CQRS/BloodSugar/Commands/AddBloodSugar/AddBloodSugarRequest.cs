﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiabetesMonitoringSystem.Domain.Enums;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.BloodSugar.Commands.AddBloodSugar
{
    public class AddBloodSugarRequest:IRequest<Unit>
    {
        public int Value { get; set; }
        public DateTime MeasurementTime { get; set; }
        public TimePeriod TimePeriod { get; set; }

        public int PatientId { get; set; }
    }
}
