using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DiabetesMonitoringSystem.Application.DTOs.UserDTOs;
using DiabetesMonitoringSystem.Application.Services;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DiabetesMonitoringSystem.Application.CQRS.User.Commands.CreateUser
{
    public class CreatePatientHandler : IRequestHandler<CreatePatientRequest, IdentityResult>
    {

        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public CreatePatientHandler(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<IdentityResult> Handle(CreatePatientRequest request, CancellationToken cancellationToken)
        {
            var value = _mapper.Map<UserRegisterDto>(request);
            var result = await _userService.CreatePatientAsync(value);
            return result;
        }
    }
}

