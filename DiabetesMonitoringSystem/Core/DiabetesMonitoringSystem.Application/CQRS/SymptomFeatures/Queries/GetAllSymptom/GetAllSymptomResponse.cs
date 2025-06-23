using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabetesMonitoringSystem.Application.CQRS.SymptomFeatures.Queries.GetAllSymptom
{
    public class GetAllSymptomResponse
    {
        public int SymptomId { get; set; }
        public string SymptomName { get; set; }
        public string? Description { get; set; }
    }
}
