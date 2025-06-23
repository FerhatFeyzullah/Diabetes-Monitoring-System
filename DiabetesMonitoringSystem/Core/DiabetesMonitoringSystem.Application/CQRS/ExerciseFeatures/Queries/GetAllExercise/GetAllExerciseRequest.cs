using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.ExerciseFeatures.Queries.GetAllExercise
{
    public class GetAllExerciseRequest:IRequest<List<GetAllExerciseResponse>>
    {
    }
}
