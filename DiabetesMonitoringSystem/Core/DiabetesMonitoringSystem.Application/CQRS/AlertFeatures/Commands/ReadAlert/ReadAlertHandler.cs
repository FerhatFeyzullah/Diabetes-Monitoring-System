using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiabetesMonitoringSystem.Application.Services;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.AlertFeatures.Commands.ReadAlert
{
    public class ReadAlertHandler(IAlertService alertService) : IRequestHandler<ReadAlertRequest, int>
    {
        public async Task<int> Handle(ReadAlertRequest request, CancellationToken cancellationToken)
        {
           var count = await alertService.ReadingAlert(request.AlertId, request.DoctorId);
            return count;
        }
    }
}
