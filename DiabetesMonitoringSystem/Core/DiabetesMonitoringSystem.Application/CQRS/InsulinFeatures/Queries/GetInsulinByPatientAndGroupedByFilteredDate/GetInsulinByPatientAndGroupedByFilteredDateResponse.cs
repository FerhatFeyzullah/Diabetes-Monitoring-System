using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiabetesMonitoringSystem.Application.DTOs.InsulinDTOs;

namespace DiabetesMonitoringSystem.Application.CQRS.InsulinFeatures.Queries.GetInsulinByPatientAndGroupedByFilteredDate
{
    public class GetInsulinByPatientAndGroupedByFilteredDateResponse
    {
        public DateOnly Date { get; set; }
        public List<InsulinDto> Doses { get; set; }
    }
}
