using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiabetesMonitoringSystem.Application.Repositories;
using DiabetesMonitoringSystem.Domain.Entities;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.DailyStatusFeatures.Commands.CreateDS_OnPrescriptionCreate
{
    public class CreateDS_OnPrecriptionCreateHandler(IWriteRepository<DailyStatus> writeRepository) : INotificationHandler<PrescriptionCreated>
    {
        public async Task Handle(PrescriptionCreated notification, CancellationToken cancellationToken)
        {
            var dailyStatus = new DailyStatus
            {
                PatientId = notification.PatientId,
                Date = DateOnly.FromDateTime(DateTime.Today),
                DietStatus = false,
                ExerciseStatus = false,              
            };
            await writeRepository.AddAsync(dailyStatus);
        }
    }
}
