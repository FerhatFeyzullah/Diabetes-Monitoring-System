using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DiabetesMonitoringSystem.Application.DTOs.UserDTOs;
using DiabetesMonitoringSystem.Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DiabetesMonitoringSystem.Application.CQRS.User.Commands.CreateUser
{
    public class CreateUserHandler : IRequestHandler<CreateUserRequest,Unit>
    {

        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public CreateUserHandler(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<Unit> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var value = _mapper.Map<UserRegisterDto>(request);
            await _userService.CreateUserAsync(value);
            return Unit.Value;
        }
    }
}

