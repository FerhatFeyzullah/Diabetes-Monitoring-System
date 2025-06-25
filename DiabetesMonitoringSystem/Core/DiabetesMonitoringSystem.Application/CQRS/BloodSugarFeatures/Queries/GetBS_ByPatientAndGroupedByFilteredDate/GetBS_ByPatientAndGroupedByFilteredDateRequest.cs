using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.BloodSugarFeatures.Queries.GetBS_ByPatientAndGroupedByFilteredDate
{
    public class GetBS_ByPatientAndGroupedByFilteredDateRequest:IRequest<List<GetBS_ByPatientAndGroupedByFilteredDateResponse>>
    {
        public int PatientId { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
    }
}
