using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.DailyStatusFeatures.Commands.UpdateDS_Diet
{
    public class UpdateDS_DietRequest:IRequest<Unit>
    {
        public int DailyStatusId { get; set; }

    }
}
