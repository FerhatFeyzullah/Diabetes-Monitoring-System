using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.DailyStatusFeatures.Commands.UpdateDS_DietOK
{
    public class UpdateDS_DietOkRequest:IRequest<Unit>
    {
        public int DailyStatusId { get; set; }

    }
}
