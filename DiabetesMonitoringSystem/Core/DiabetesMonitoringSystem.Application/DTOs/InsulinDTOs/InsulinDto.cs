using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiabetesMonitoringSystem.Domain.Enums;

namespace DiabetesMonitoringSystem.Application.DTOs.InsulinDTOs
{
    public class InsulinDto
    {
        public int InsulinId { get; set; }
        public int Dose { get; set; }
        public TimePeriod TimePeriod { get; set; }
    }
}
