﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.BloodSugarFeatures.Queries.GetBS_ByPatientAndGroupedByDate
{
    public class BloodSugarListByDateRequest:IRequest<List<BloodSugarListByDateResponse>>
    {
        public int PatientId { get; set; }
    }
}
