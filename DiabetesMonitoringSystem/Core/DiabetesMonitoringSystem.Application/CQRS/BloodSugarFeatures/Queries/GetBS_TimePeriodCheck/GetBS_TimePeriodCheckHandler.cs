using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiabetesMonitoringSystem.Application.Repositories;
using DiabetesMonitoringSystem.Application.Services;
using DiabetesMonitoringSystem.Domain.Entities;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.BloodSugarFeatures.Queries.GetBS_TimePeriodCheck
{
    public class GetBS_TimePeriodCheckHandler(IBloodSugarService bloodSugarService) : IRequestHandler<GetBS_TimePeriodCheckRequest, bool>
    {
        public async Task<bool> Handle(GetBS_TimePeriodCheckRequest request, CancellationToken cancellationToken)
        {
            return await bloodSugarService.GetBS_TimePeriodCheck(request.PatientId, request.TimePeriod);

        }
    }
}
