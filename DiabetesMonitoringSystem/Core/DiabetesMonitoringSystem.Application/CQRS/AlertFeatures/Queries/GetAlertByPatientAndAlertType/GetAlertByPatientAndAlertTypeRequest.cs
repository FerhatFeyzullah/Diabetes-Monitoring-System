using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiabetesMonitoringSystem.Domain.Enums;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.AlertFeatures.Queries.GetAlertByPatientAndAlertType
{
    public class GetAlertByPatientAndAlertTypeRequest:IRequest<List<GetAlertByPatientAndAlertTypeResponse>>
    {
        public int PatientId { get; set; }
        public AlertType AlertType { get; set; }
    }
}
