using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DiabetesMonitoringSystem.Application.Repositories;
using DiabetesMonitoringSystem.Domain.Entities;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.PrescriptionFeatures.Queries.GetPrescriptionByPatient
{
    public class GetPrescriptionByPatientHandler(IReadRepository<Prescription> readRepository,IMapper mapper) : IRequestHandler<GetPrescriptionByPatientRequest, GetPrescriptionByPatientResponse>
    {
        public async Task<GetPrescriptionByPatientResponse> Handle(GetPrescriptionByPatientRequest request, CancellationToken cancellationToken)
        {
            var value = await readRepository.GetByFiltered(x => x.PatientId == request.PatientId
            , x => x.Doctor, x => x.Patient, x => x.Diet, x => x.Exercise
            );

            return mapper.Map<GetPrescriptionByPatientResponse>(value);



        }
    }
}
