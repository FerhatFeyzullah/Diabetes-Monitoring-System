using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DiabetesMonitoringSystem.Application.Repositories;
using DiabetesMonitoringSystem.Domain.Entities;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.PrescriptionFeatures.Queries.GetPrescriptionByPatient
{
    public class GetPrescriptionByPatientHandler(IReadRepository<Prescription> readRepository,IMapper mapper) : IRequestHandler<GetPrescriptionByPatientRequest, List<GetPrescriptionByPatientResponse>>
    {
        public async Task<List<GetPrescriptionByPatientResponse>> Handle(GetPrescriptionByPatientRequest request, CancellationToken cancellationToken)
        {
            var values = await readRepository.GetByFilteredList(
                 x=>x.PatientId == request.PatientId,
                    x => x.Diet,
                    x => x.Exercise
                 );
            return mapper.Map<List<GetPrescriptionByPatientResponse>>(values);
        }
    }
}
