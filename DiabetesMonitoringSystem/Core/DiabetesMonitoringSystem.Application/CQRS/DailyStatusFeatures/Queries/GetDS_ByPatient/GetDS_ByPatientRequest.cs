using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.DailyStatusFeatures.Queries.GetDS_ByPatient
{
    public class GetDS_ByPatientRequest:IRequest<List<GetDS_ByPatientResponse>>
    {
        public int PatientId { get; set; }
       
    }
}
