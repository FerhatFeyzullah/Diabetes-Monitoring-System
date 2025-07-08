using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiabetesMonitoringSystem.Application.Repositories;
using DiabetesMonitoringSystem.Domain.Entities;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.PrescriptionFeatures.Queries.GetPercentageOfDailyStatus
{
    public class GetPercentageOfPrescriptionHandler(IReadRepository<DailyStatus> readRepository) : IRequestHandler<GetPercentageOfPrescriptionRequest,GetPercentageOfPrescriptionResponse>
    {
        public async Task<GetPercentageOfPrescriptionResponse> Handle(GetPercentageOfPrescriptionRequest request, CancellationToken cancellationToken)
        {
            var totalDS = await readRepository.FilteredCountAsync(p => p.PatientId == request.PatientId);
            var  prescriptionCount = await readRepository.FilteredCountAsync(p => p.PatientId == request.PatientId && p.PrescriptionAvailable);
            var  dietCount = await readRepository.FilteredCountAsync(p => p.PatientId == request.PatientId && p.DietStatus);
            var  exerciseCount = await readRepository.FilteredCountAsync(p => p.PatientId == request.PatientId && p.ExerciseStatus);

            if (totalDS == 0)           
            {
                return new GetPercentageOfPrescriptionResponse
                {
                    PrescriptionPercentage = "0.00",
                    DietPercentage = "0.00",
                    ExercisePercentage = "0.00"
                };
            }              

            double p_percentage = (double)prescriptionCount / totalDS * 100;
            double d_percentage = (double)dietCount / totalDS * 100;
            double e_percentage = (double)exerciseCount / totalDS * 100;

            string p_result = p_percentage.ToString("0.00");
            string d_result = d_percentage.ToString("0.00");
            string e_result = e_percentage.ToString("0.00");

            return new GetPercentageOfPrescriptionResponse
            {
                PrescriptionPercentage = p_result,
                DietPercentage = d_result,
                ExercisePercentage = e_result
            };
            
        }
    }
}
