using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.PrescriptionFeatures.Commands.UpdatePrescription
{
    public class UpdatePrescriptionRequest:IRequest<Unit>
    {
        public int PrescriptionId { get; set; }
        public int DietId { get; set; }
        public int ExerciseId { get; set; }
        public int PatientId { get; set; }
    }
}
