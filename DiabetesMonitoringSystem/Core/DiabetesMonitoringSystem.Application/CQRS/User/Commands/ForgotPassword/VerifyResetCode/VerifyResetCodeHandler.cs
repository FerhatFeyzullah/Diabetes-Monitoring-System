using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiabetesMonitoringSystem.Application.Services;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.User.Commands.ForgotPassword.VerifyResetCode
{
    public class VerifyResetCodeHandler(IForgotPasswordService forgotPasswordService) : IRequestHandler<VerifyResetCodeRequest, bool>
    {
        public async Task<bool> Handle(VerifyResetCodeRequest request, CancellationToken cancellationToken)
        {           
            return await forgotPasswordService.VerifyResetCode(request.Email, request.VerifyCode);
        }
    }
}
