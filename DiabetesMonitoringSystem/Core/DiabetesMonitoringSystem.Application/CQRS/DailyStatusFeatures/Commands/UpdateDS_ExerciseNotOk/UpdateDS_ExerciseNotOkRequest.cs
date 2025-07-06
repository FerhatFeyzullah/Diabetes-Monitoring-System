using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.DailyStatusFeatures.Commands.UpdateDS_ExerciseNotOk
{
    public class UpdateDS_ExerciseNotOkRequest: IRequest<Unit>
    {
        public int DailyStatusId { get; set; }
    }
}
