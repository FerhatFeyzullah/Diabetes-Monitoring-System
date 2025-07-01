using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DiabetesMonitoringSystem.Application.CQRS.DailyStatusFeatures.Queries.GetDS_ByPatientAndDate;
using DiabetesMonitoringSystem.Application.Repositories;
using DiabetesMonitoringSystem.Domain.Entities;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.PrescriptionFeatures.Queries.GetPrescriptionByPatientAndDateDaily
{
    public class GetPrescriptionByPatientAndDateDailyHandler(IReadRepository<Prescription> readRepository, IMapper mapper) : IRequestHandler<GetPrescriptionByPatientAndDateDailyRequest, GetPrescriptionByPatientAndDateDailyResponse>
    {
        public async Task<GetPrescriptionByPatientAndDateDailyResponse> Handle(GetPrescriptionByPatientAndDateDailyRequest request, CancellationToken cancellationToken)
        {
            var value = await readRepository.GetByFiltered(
                x => x.PatientId == request.PatientId &&
                x.PrescriptionDate == DateOnly.FromDateTime(DateTime.Today)
                );
            return mapper.Map<GetPrescriptionByPatientAndDateDailyResponse>(value);
        }
    }
}
