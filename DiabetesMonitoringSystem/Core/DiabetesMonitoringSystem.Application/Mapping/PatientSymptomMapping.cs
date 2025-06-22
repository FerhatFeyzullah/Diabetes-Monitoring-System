using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DiabetesMonitoringSystem.Application.CQRS.PatientSymptomFeatures.Commands;
using DiabetesMonitoringSystem.Application.CQRS.PatientSymptomFeatures.Queries;
using DiabetesMonitoringSystem.Domain.Entities;

namespace DiabetesMonitoringSystem.Application.Mapping
{
    public class PatientSymptomMapping:Profile
    {
        public PatientSymptomMapping()
        {
            CreateMap<PatientSymptom, GetPS_ByPatientResponse>().ReverseMap();
            CreateMap<PatientSymptom, CreatePatientSymptomRequest>().ReverseMap();
        }
    }
}
