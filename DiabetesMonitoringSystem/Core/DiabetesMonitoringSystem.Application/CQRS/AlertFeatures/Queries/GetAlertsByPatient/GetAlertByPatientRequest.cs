using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.AlertFeatures.Queries.GetAlertsByPatient
{
    public class GetAlertByPatientRequest:IRequest<List<GetAlertByPatientResponse>>
    {
        public int PatientId { get; set; }
    }
}
