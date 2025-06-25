using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiabetesMonitoringSystem.Application.Services;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace DiabetesMonitoringSystem.Application.CQRS.User.Commands.ForgotPassword.ChangeForgotPassword
{
    public class ChangeForgotPasswordHandler(IUserService userService) : IRequestHandler<ChangeForgotPasswordRequest, IdentityResult>
    {
        public async Task<IdentityResult> Handle(ChangeForgotPasswordRequest request, CancellationToken cancellationToken)
        {           
            return await userService.ChangeForgotPassword(request.Email, request.NewPassword, request.ConfirmNewPassword);
        }
    }
}
