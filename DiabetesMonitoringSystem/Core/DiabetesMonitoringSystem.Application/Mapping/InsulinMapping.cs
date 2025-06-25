using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DiabetesMonitoringSystem.Application.CQRS.InsulinFeatures.Queries.GetInsulinByPatientAndGroupedByDate;
using DiabetesMonitoringSystem.Application.CQRS.InsulinFeatures.Queries.GetInsulinByPatientAndGroupedByFilteredDate;
using DiabetesMonitoringSystem.Application.DTOs.InsulinDTOs;
using DiabetesMonitoringSystem.Domain.Entities;

namespace DiabetesMonitoringSystem.Application.Mapping
{
    public class InsulinMapping:Profile
    {
        public InsulinMapping()
        {
            CreateMap<GetInsulinByPatientAndGroupedByDateResponse, DailyInsulinGroupDto>().ReverseMap();
            CreateMap<GetInsulinByPatientAndGroupedByFilteredDateResponse, DailyInsulinGroupDto>().ReverseMap();
        }
    }
}
