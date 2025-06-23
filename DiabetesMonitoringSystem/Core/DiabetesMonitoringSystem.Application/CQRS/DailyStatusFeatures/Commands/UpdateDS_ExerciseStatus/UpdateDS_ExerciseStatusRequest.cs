using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.DailyStatusFeatures.Commands.UpdateDS_ExerciseStatus
{
    public class UpdateDS_ExerciseStatusRequest:IRequest<Unit>
    {
        public int DailyStatusId { get; set; }
        public int PatientId { get; set; }
        public bool ExerciseStatus { get; set; }
        public bool DietStatus { get; set; }

    }
}
