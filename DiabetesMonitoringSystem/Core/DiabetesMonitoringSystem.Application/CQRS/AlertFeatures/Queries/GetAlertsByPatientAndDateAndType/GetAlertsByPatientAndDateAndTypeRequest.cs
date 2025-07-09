using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiabetesMonitoringSystem.Domain.Enums;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.AlertFeatures.Queries.GetAlertsByPatientAndDateAndType
{
    public class GetAlertsByPatientAndDateAndTypeRequest:IRequest<List<GetAlertsByPatientAndDateAndTypeResponse>>
    {
        public int PatientId { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public AlertType AlertType { get; set; }

    }
}
