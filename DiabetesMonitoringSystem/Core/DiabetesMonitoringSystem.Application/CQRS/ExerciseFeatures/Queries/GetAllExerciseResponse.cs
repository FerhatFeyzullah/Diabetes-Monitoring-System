using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabetesMonitoringSystem.Application.CQRS.ExerciseFeatures.Queries
{
    public class GetAllExerciseResponse
    {
        public int ExerciseId { get; set; }
        public string ExerciseType { get; set; }
        public string Description { get; set; }
    }
}
