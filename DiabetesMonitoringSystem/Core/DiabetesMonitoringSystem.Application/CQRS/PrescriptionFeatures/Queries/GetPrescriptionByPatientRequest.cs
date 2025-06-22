using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.PrescriptionFeatures.Queries
{
    public class GetPrescriptionByPatientRequest:IRequest<GetPrescriptionByPatientResponse>
    {
        public int PatientId { get; set; }
    }
}
