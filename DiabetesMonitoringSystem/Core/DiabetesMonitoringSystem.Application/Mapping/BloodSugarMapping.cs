using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DiabetesMonitoringSystem.Application.CQRS.BloodSugarFeatures.Commands.AddBloodSugar;
using DiabetesMonitoringSystem.Application.CQRS.BloodSugarFeatures.Queries.GetBS_ByPatientAndGroupedByDate;
using DiabetesMonitoringSystem.Application.CQRS.BloodSugarFeatures.Queries.GetBS_ByPatientAndGroupedByFilteredDate;
using DiabetesMonitoringSystem.Application.DTOs.BloodSugarDTOs;
using DiabetesMonitoringSystem.Domain.Entities;

namespace DiabetesMonitoringSystem.Application.Mapping
{
    public class BloodSugarMapping:Profile
    {
        public BloodSugarMapping()
        {
            CreateMap<BloodSugar, AddBloodSugarRequest>().ReverseMap();
            CreateMap<DailyBloodSugarGroupDto,BloodSugarListByDateResponse>().ReverseMap();
            CreateMap<DailyBloodSugarGroupDto, GetBS_ByPatientAndGroupedByFilteredDateResponse>().ReverseMap();
        }
    }
}
