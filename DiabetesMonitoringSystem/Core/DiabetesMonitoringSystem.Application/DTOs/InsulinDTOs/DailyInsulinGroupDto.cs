using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabetesMonitoringSystem.Application.DTOs.InsulinDTOs
{
    public class DailyInsulinGroupDto
    {
        public DateOnly Date { get; set; }
        public List<InsulinDto> Doses { get; set; }
    }
}
