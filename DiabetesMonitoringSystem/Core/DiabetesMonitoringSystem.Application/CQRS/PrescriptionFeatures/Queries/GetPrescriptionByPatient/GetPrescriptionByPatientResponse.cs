using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiabetesMonitoringSystem.Application.DTOs.UserDTOs;
using DiabetesMonitoringSystem.Domain.Entities;

namespace DiabetesMonitoringSystem.Application.CQRS.PrescriptionFeatures.Queries.GetPrescriptionByPatient
{
    public class GetPrescriptionByPatientResponse
    {
        public int PrescriptionId { get; set; }
        public DateOnly PrescriptionDate { get; set; }
        public string Comment { get; set; }



        public int DietId { get; set; }
        public Diet Diet { get; set; }
        public int ExerciseId { get; set; }
        public Exercise Exercise { get; set; }

        public int PatientId { get; set; }
        public ResultUserDto Patient { get; set; }

        public int DoctorId { get; set; }
        public ResultUserDto Doctor { get; set; }
    }
}
