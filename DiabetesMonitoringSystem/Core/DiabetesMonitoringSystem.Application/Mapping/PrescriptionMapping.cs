using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DiabetesMonitoringSystem.Application.CQRS.PrescriptionFeatures.Commands.UpdatePrescription;
using DiabetesMonitoringSystem.Application.CQRS.PrescriptionFeatures.Queries.GetPrescriptionByPatientAndDate;
using DiabetesMonitoringSystem.Application.CQRS.PrescriptionFeatures.Queries.GetPrescriptionByPatientAndDateDaily;
using DiabetesMonitoringSystem.Application.CQRS.PrescriptionFeatures.Queries.GetPrescriptionByPatientAndFilteredDate;
using DiabetesMonitoringSystem.Domain.Entities;

namespace DiabetesMonitoringSystem.Application.Mapping
{
    public class PrescriptionMapping:Profile
    {
        public PrescriptionMapping()
        {
            CreateMap<Prescription, GetPrescriptionByPatientAndDateResponse>().ReverseMap();
            CreateMap<Prescription, GetPrescriptionByPatientAndDateDailyResponse>().ReverseMap();           
            CreateMap<Prescription, GetPrescriptionByPatientAndFilteredDateResponse>().ReverseMap();
            CreateMap<Prescription, UpdatePrescriptionRequest>().ReverseMap();


        }
    }
}
