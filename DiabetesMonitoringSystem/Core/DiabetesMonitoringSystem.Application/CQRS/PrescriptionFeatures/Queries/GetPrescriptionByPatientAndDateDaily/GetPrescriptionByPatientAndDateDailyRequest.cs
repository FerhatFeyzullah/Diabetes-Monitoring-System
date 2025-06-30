using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.PrescriptionFeatures.Queries.GetPrescriptionByPatientAndDateDaily
{
    public class GetPrescriptionByPatientAndDateDailyRequest:IRequest<GetPrescriptionByPatientAndDateDailyResponse>
    {
        public int PatientId { get; set; }
    }
}
