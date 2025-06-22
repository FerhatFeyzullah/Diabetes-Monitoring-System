using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.DailyStatusFeatures.Commands.UpdateDS_DietStatus
{
    public class UpdateDS_DietStatusRequest:IRequest<Unit>
    {
        public int PatientId { get; set; }       
        public bool DietStatus { get; set; }
    }
}
