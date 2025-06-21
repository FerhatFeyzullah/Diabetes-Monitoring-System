using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DiabetesMonitoringSystem.Application.DTOs.UserDTOs;
using DiabetesMonitoringSystem.Application.Services;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.User.Commands.LoginTheSystem
{
    public class LoginTheSystemHandler(IUserService userService,IMapper mapper) : IRequestHandler<LoginTheSystemRequest, string>
    {
        public async Task<string> Handle(LoginTheSystemRequest request, CancellationToken cancellationToken)
        {
            var value = mapper.Map<UserLoginDto>(request);
            var token = await userService.LoginAsync(value);
            return token;
        }
    }
}
