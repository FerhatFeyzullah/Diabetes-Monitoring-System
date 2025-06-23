using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DiabetesMonitoringSystem.Application.CQRS.DietFeatures.Commands.CreateDiet;
using DiabetesMonitoringSystem.Application.CQRS.DietFeatures.Queries.GetAllDiet;
using DiabetesMonitoringSystem.Domain.Entities;

namespace DiabetesMonitoringSystem.Application.Mapping
{
    public class DietMapping:Profile
    {
        public DietMapping()
        {
            CreateMap<Diet, CreateDietRequest>().ReverseMap();
            CreateMap<Diet, GetAllDietResponse>().ReverseMap();

        }
    }
}
