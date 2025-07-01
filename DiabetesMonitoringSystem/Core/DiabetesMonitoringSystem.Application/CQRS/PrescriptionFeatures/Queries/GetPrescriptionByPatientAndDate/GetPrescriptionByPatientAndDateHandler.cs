using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DiabetesMonitoringSystem.Application.Repositories;
using DiabetesMonitoringSystem.Domain.Entities;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.PrescriptionFeatures.Queries.GetPrescriptionByPatientAndDate
{
    public class GetPrescriptionByPatientAndDateHandler(IReadRepository<Prescription> readRepository,IMapper mapper) : IRequestHandler<GetPrescriptionByPatientAndDateRequest, List<GetPrescriptionByPatientAndDateResponse>>
    {
        public async Task<List<GetPrescriptionByPatientAndDateResponse>> Handle(GetPrescriptionByPatientAndDateRequest request, CancellationToken cancellationToken)
        {
            var values = await readRepository.GetByFilteredList(
                 x=>x.PatientId == request.PatientId
                 );
            return mapper.Map<List<GetPrescriptionByPatientAndDateResponse>>(values);
        }
    }
}
