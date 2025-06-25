using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DiabetesMonitoringSystem.Application.CQRS.AlertFeatures.Queries.GetAlertByPatientAndAlertType;
using DiabetesMonitoringSystem.Application.CQRS.AlertFeatures.Queries.GetAlertsByPatient;
using DiabetesMonitoringSystem.Application.CQRS.AlertFeatures.Queries.GetAlertsByPatientAndDate;
using DiabetesMonitoringSystem.Domain.Entities;

namespace DiabetesMonitoringSystem.Application.Mapping
{
    public class AlertMapping:Profile
    {
        public AlertMapping()
        {
            CreateMap<Alert, GetAlertByPatientResponse>().ReverseMap();
            CreateMap<Alert, GetAlertsByPatientAndDateResponse>().ReverseMap();
            CreateMap<Alert, GetAlertByPatientAndAlertTypeResponse>().ReverseMap();
                
        }
    }
}
