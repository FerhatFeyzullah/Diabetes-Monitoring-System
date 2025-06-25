using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.AlertFeatures.Queries.GetAlertsByPatientAndDate
{
    public class GetAlertsByPatientAndDateRequest:IRequest<List<GetAlertsByPatientAndDateResponse>>
    {
        public int PatientId { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
    }
}
