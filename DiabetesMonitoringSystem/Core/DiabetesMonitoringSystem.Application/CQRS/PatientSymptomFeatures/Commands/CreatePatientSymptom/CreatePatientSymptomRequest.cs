using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiabetesMonitoringSystem.Domain.Entities;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.PatientSymptomFeatures.Commands.CreatePatientSymptom
{
    public class CreatePatientSymptomRequest:IRequest<Unit>
    {
        public int SymptomId { get; set; }       
        public int PatientId { get; set; }
        public DateOnly SymptomDate { get; set; }
    }
}
