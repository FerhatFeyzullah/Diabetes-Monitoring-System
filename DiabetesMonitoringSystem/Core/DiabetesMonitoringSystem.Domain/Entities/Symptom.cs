using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiabetesMonitoringSystem.Domain.Enums;

namespace DiabetesMonitoringSystem.Domain.Entities
{
    public class Symptom
    {
        public int SymptomId { get; set; }
        public string SymptomName { get; set; }
        public string? Description { get; set; }
    }
}
