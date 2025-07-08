using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.AlertFeatures.Commands.ReadAlert
{
    public class ReadAlertRequest:IRequest<int>
    {
        public int AlertId { get; set; }
        public int DoctorId { get; set; }
    }
}
