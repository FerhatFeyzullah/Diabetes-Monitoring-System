using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.DietFeatures.Commands
{
    public class CreateDietRequest:IRequest<Unit>
    {
        public string DietType { get; set; }
        public string Description { get; set; }
    }
}
