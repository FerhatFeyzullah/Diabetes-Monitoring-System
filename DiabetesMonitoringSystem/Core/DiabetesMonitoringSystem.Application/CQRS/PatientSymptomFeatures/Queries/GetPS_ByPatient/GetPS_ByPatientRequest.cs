using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.PatientSymptomFeatures.Queries.GetPS_ByPatient
{
    public class GetPS_ByPatientRequest:IRequest<List<GetPS_ByPatientResponse>>
    {
        public int PatientId { get; set; }
    }
}
