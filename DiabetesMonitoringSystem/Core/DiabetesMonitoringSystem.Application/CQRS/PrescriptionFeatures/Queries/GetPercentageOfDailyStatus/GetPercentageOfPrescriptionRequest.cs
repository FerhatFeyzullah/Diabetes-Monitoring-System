﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.PrescriptionFeatures.Queries.GetPercentageOfDailyStatus
{
    public class GetPercentageOfPrescriptionRequest:IRequest<GetPercentageOfPrescriptionResponse>
    {
        public int PatientId { get; set; }
    }
}
