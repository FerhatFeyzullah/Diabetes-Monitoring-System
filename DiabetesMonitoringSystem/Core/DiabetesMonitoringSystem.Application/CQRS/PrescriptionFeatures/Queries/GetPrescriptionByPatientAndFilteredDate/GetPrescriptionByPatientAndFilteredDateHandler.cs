using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DiabetesMonitoringSystem.Application.Repositories;
using DiabetesMonitoringSystem.Domain.Entities;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.PrescriptionFeatures.Queries.GetPrescriptionByPatientAndFilteredDate
{
    public class GetPrescriptionByPatientAndFilteredDateHandler(IReadRepository<Prescription> readRepository, IMapper mapper)
        : IRequestHandler<GetPrescriptionByPatientAndFilteredDateRequest, List<GetPrescriptionByPatientAndFilteredDateResponse>>
    {
        public async Task<List<GetPrescriptionByPatientAndFilteredDateResponse>> Handle(GetPrescriptionByPatientAndFilteredDateRequest request, CancellationToken cancellationToken)
        {
            var values = await readRepository.GetByFilteredList(
                 x => x.PatientId == request.PatientId && x.PrescriptionDate >=request.Start && x.PrescriptionDate <=request.End,
                    x => x.Diet,
                    x => x.Exercise
                 );
            return mapper.Map<List<GetPrescriptionByPatientAndFilteredDateResponse>>(values);
        }
    }
}
