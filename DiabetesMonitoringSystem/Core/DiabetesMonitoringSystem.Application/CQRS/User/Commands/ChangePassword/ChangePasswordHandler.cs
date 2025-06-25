using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiabetesMonitoringSystem.Application.Services;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace DiabetesMonitoringSystem.Application.CQRS.User.Commands.ChangePassword
{
    public class ChangePasswordHandler(IUserService userService) : IRequestHandler<ChangePasswordRequest, IdentityResult>
    {
        public async Task<IdentityResult> Handle(ChangePasswordRequest request, CancellationToken cancellationToken)
        {
            return await userService.ChangePassword(request.AppUserId, request.OldPassword, request.NewPassword, request.ConfirmNewPassword);
        }
    }
}
