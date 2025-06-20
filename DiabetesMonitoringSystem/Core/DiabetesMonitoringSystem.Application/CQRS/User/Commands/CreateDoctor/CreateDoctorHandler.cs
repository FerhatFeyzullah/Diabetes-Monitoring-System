using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DiabetesMonitoringSystem.Application.DTOs.UserDTOs;
using DiabetesMonitoringSystem.Application.Services;
using DiabetesMonitoringSystem.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace DiabetesMonitoringSystem.Application.CQRS.User.Commands.CreateDoctor
{
    public class CreateDoctorHandler(IUserService userService,IMapper mapper) : IRequestHandler<CreateDoctorRequest, IdentityResult>
    {
        public async Task<IdentityResult> Handle(CreateDoctorRequest request, CancellationToken cancellationToken)
        {
            var value = mapper.Map<UserRegisterDto>(request);
            return await userService.CreateDoctorAsync(value);
           
        }
    }
}
