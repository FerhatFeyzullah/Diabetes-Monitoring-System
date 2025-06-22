using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiabetesMonitoringSystem.Domain.Enums;

namespace DiabetesMonitoringSystem.Application.DTOs.BloodSugarDTOs
{
    public class BloodSugarDto
    {
        public int BloodSugarId { get; set; }
        public int Value { get; set; }
        public TimePeriod TimePeriod { get; set; }
    }
}
