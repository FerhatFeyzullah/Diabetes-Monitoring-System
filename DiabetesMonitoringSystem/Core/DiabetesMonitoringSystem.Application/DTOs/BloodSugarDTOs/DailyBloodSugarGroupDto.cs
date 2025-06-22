using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabetesMonitoringSystem.Application.DTOs.BloodSugarDTOs
{
    public class DailyBloodSugarGroupDto
    {
        public DateOnly MeasurementTime { get; set; }
        public List<BloodSugarDto> Measurements { get; set; }
    }
}
