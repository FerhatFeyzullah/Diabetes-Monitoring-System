using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DiabetesMonitoringSystem.Application.CQRS.DailyStatusFeatures.Commands.CreateDS;
using DiabetesMonitoringSystem.Application.CQRS.DailyStatusFeatures.Commands.UpdateDS;
using DiabetesMonitoringSystem.Application.CQRS.DailyStatusFeatures.Queries.GetDS_ByPatient;
using DiabetesMonitoringSystem.Application.CQRS.DailyStatusFeatures.Queries.GetDS_ByPatientAndDate;
using DiabetesMonitoringSystem.Application.CQRS.DailyStatusFeatures.Queries.GetDS_ByPatientAndFilteredDate;
using DiabetesMonitoringSystem.Domain.Entities;

namespace DiabetesMonitoringSystem.Application.Mapping
{
    public class DailyStatusMapping:Profile
    {
        public DailyStatusMapping()
        {
            CreateMap<DailyStatus, CreateDS_Request>().ReverseMap();
            CreateMap<DailyStatus, UpdateDSRequest>().ReverseMap();
            CreateMap<DailyStatus, GetDS_ByPatientResponse>().ReverseMap();
            CreateMap<DailyStatus, GetDS_ByPatientAndDateResponse>().ReverseMap();
            CreateMap<DailyStatus, GetDS_ByPatientAndFilteredDateResponse>().ReverseMap();
        }
    }
}
