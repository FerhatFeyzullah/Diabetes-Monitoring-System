using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiabetesMonitoringSystem.Domain.Entities;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.DailyStatusFeatures.Commands.UpdateDS
{
    public class UpdateDSRequest:IRequest<Unit>
    {
        public int DailyStatusId { get; set; }
        public int PatientId { get; set; }
        public bool DietStatus { get; set; }
        public bool ExerciseStatus { get; set; }
        public bool PrescriptionAvailable { get; set; }

    }
}
