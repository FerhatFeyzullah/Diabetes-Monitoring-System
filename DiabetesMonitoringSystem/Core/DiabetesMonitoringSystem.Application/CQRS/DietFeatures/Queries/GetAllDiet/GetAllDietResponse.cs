using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabetesMonitoringSystem.Application.CQRS.DietFeatures.Queries.GetAllDiet
{
    public class GetAllDietResponse
    {
        public int DietId { get; set; }
        public string DietType { get; set; }
        public string Description { get; set; }
    }
}
