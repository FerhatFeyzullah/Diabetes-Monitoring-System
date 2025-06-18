using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiabetesMonitoringSystem.Domain.Enums;


namespace DiabetesMonitoringSystem.Domain.Entities
{
    public class Exercise
    {
        public int ExerciseId { get; set; }
        public string ExerciseType { get; set; }
        public string Description { get; set; }
    }
}
