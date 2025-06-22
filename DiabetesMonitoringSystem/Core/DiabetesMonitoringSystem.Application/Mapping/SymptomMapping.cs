using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DiabetesMonitoringSystem.Application.CQRS.SymptomFeatures.Queries;
using DiabetesMonitoringSystem.Domain.Entities;

namespace DiabetesMonitoringSystem.Application.Mapping
{
    public class SymptomMapping:Profile
    {
        public SymptomMapping()
        {
            CreateMap<Symptom,GetAllSymptomResponse>().ReverseMap();
        }
    }
}
