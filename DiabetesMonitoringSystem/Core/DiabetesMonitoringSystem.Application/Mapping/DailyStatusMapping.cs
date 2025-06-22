using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DiabetesMonitoringSystem.Application.CQRS.DailyStatusFeatures.Commands.CreateDS;
using DiabetesMonitoringSystem.Application.CQRS.DailyStatusFeatures.Commands.UpdateDS_DietStatus;
using DiabetesMonitoringSystem.Application.CQRS.DailyStatusFeatures.Commands.UpdateDS_ExerciseStatus;
using DiabetesMonitoringSystem.Application.CQRS.DailyStatusFeatures.Queries.GetDS_ByDate;
using DiabetesMonitoringSystem.Application.CQRS.DailyStatusFeatures.Queries.GetDS_ByPatient;
using DiabetesMonitoringSystem.Domain.Entities;

namespace DiabetesMonitoringSystem.Application.Mapping
{
    public class DailyStatusMapping:Profile
    {
        public DailyStatusMapping()
        {
            CreateMap<DailyStatus, CreateDS_Request>().ReverseMap();
            CreateMap<DailyStatus, UpdateDS_DietStatusRequest>().ReverseMap();
            CreateMap<DailyStatus, UpdateDS_ExerciseStatusRequest>().ReverseMap();
            CreateMap<DailyStatus, GetDS_ByPatientResponse>().ReverseMap();
            CreateMap<DailyStatus, GetDS_ByDateResponse>().ReverseMap();
        }
    }
}
