using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabetesMonitoringSystem.Application.CQRS.PrescriptionFeatures.Queries.GetPercentageOfDailyStatus
{
    public class GetPercentageOfPrescriptionResponse
    {
        public string PrescriptionPercentage { get; set; }
        public string DietPercentage { get; set; }
        public string ExercisePercentage { get; set; }
    }
}
