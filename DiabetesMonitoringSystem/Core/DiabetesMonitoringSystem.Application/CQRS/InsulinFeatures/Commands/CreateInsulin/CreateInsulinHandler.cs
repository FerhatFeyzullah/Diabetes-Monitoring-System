using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiabetesMonitoringSystem.Application.Services;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.InsulinFeatures.Commands.CreateInsulin
{
    public class CreateInsulinHandler(IInsulinService insulinService) : IRequestHandler<CreateInsulinRequest, int>
    {
        public async  Task<int> Handle(CreateInsulinRequest request, CancellationToken cancellationToken)
        {
            var timePeriod = request.TimePeriod;
            var patientId = request.PatientId;
            var date = request.Date;

            var value = await insulinService.InsulinCreateBasedOnBloodSugar(timePeriod, patientId, date);
            return value;
        }
    }
}
