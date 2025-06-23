using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiabetesMonitoringSystem.Domain.Entities;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.PrescriptionFeatures.Commands.CreatePrescription
{
    public class CreatePrescriptionRequest:IRequest<Unit>
    {
        public string Comment { get; set; }

        public int DietId { get; set; }
      
        public int ExerciseId { get; set; }
       
        public int PatientId { get; set; }
   
        public int DoctorId { get; set; }
      
    }
}
