using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DiabetesMonitoringSystem.Application.Repositories;
using DiabetesMonitoringSystem.Domain.Entities;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.PatientSymptomFeatures.Commands.CreatePatientSymptom
{
    public class CreatePatientSymptomHandler(IWriteRepository<PatientSymptom> writeRepository,IMapper mapper) : IRequestHandler<CreatePatientSymptomRequest, Unit>
    {
        public async Task<Unit> Handle(CreatePatientSymptomRequest request, CancellationToken cancellationToken)
        {
            var patientSymptom = mapper.Map<PatientSymptom>(request);
            await writeRepository.AddAsync(patientSymptom);
            return Unit.Value;
        }
    }
}
