using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiabetesMonitoringSystem.Application.DTOs.BloodSugarDTOs;

namespace DiabetesMonitoringSystem.Application.CQRS.BloodSugarFeatures.Queries.GetBS_ByPatientAndGroupedByDate
{
    public class BloodSugarListByDateResponse
    {
        public DateOnly MeasurementTime { get; set; }
        public List<BloodSugarDto> Measurements { get; set; }
    }
}
