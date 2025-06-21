using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiabetesMonitoringSystem.Application.Services;
using DiabetesMonitoringSystem.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace DiabetesMonitoringSystem.Application.CQRS.User.Commands.LogoutTheSystem
{
    public class LogoutTheSystemHandler(IUserService userService) : IRequestHandler<LogoutTheSystemRequest, Unit>
    {
        public async Task<Unit> Handle(LogoutTheSystemRequest request, CancellationToken cancellationToken)
        {
            await userService.LogoutAsync();
            return Unit.Value;
        }
    }
}
