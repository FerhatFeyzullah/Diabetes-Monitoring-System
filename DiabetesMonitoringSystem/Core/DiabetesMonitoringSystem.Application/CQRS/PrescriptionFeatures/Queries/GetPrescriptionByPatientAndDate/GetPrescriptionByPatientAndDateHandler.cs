﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DiabetesMonitoringSystem.Application.CQRS.DailyStatusFeatures.Queries.GetDS_ByPatientAndDate;
using DiabetesMonitoringSystem.Application.Repositories;
using DiabetesMonitoringSystem.Domain.Entities;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.PrescriptionFeatures.Queries.GetPrescriptionByPatientAndDate
{
    public class GetPrescriptionByPatientAndDateHandler(IReadRepository<Prescription> readRepository, IMapper mapper) : IRequestHandler<GetPrescriptionByPatientAndDateRequest, GetPrescriptionByPatientAndDateResponse>
    {
        public async Task<GetPrescriptionByPatientAndDateResponse> Handle(GetPrescriptionByPatientAndDateRequest request, CancellationToken cancellationToken)
        {
            var value = await readRepository.GetByFiltered(
                x => x.PatientId == request.PatientId &&
                x.PrescriptionDate == DateOnly.FromDateTime(DateTime.Today),
                v => v.Diet,
                v => v.Exercise
                );
            return mapper.Map<GetPrescriptionByPatientAndDateResponse>(value);
        }
    }
}
