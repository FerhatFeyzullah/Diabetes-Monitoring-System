using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DiabetesMonitoringSystem.Application.CQRS.PrescriptionFeatures.Commands.CreatePrescription;
using DiabetesMonitoringSystem.Application.CQRS.PrescriptionFeatures.Queries.GetPrescriptionByPatient;
using DiabetesMonitoringSystem.Domain.Entities;

namespace DiabetesMonitoringSystem.Application.Mapping
{
    public class PrescriptionMapping:Profile
    {
        public PrescriptionMapping()
        {
            CreateMap<Prescription, CreatePrescriptionRequest>().ReverseMap();
            CreateMap<Prescription, GetPrescriptionByPatientResponse>().ReverseMap();
        }
    }
}
