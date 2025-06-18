using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiabetesMonitoringSystem.Domain.Enums;

namespace DiabetesMonitoringSystem.Domain.Entities
{
    public class Diet
    {
        public int DietId { get; set; }
        public string DietType { get; set; }
        public string Description { get; set; }


    }
}
