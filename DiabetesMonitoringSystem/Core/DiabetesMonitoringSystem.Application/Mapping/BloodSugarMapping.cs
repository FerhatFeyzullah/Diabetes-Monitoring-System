using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DiabetesMonitoringSystem.Application.CQRS.BloodSugarFeatures.Commands.AddBloodSugar;
using DiabetesMonitoringSystem.Domain.Entities;

namespace DiabetesMonitoringSystem.Application.Mapping
{
    public class BloodSugarMapping:Profile
    {
        public BloodSugarMapping()
        {
            CreateMap<BloodSugar, AddBloodSugarRequest>().ReverseMap();
        }
    }
}
