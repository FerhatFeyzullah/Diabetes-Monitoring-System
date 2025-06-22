using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiabetesMonitoringSystem.Domain.Entities;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.DailyStatusFeatures.Commands.CreateDS
{
    public class CreateDS_Request:IRequest<Unit>
    {
        public int PatientId { get; set; }
        public DateOnly Date { get; set; }
        public bool ExerciseStatus { get; set; }
        public bool DietStatus { get; set; }
    }
}
