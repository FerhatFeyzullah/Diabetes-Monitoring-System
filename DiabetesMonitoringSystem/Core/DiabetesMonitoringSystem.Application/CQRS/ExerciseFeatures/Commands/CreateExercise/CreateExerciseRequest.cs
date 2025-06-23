using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.ExerciseFeatures.Commands.CreateExercise
{
    public class CreateExerciseRequest:IRequest<Unit>
    {
        public string ExerciseType { get; set; }
        public string Description { get; set; }
    }
}
