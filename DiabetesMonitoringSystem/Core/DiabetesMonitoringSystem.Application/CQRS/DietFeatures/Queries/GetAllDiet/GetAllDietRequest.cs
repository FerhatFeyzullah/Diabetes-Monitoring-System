﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.DietFeatures.Queries.GetAllDiet
{
    public class GetAllDietRequest:IRequest<List<GetAllDietResponse>>
    {

    }
}
