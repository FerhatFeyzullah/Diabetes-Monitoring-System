using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiabetesMonitoringSystem.Domain.Enums;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.BloodSugarFeatures.Queries.GetBS_TimePeriodCheck
{
    public class GetBS_TimePeriodCheckRequest:IRequest<bool>
    {
        public int PatientId { get; set; }
        public TimePeriod TimePeriod { get; set; }
    }
}
