using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiabetesMonitoringSystem.Application.Services;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.User.Commands.ForgotPassword.SendResetCode
{
    public class SendResetCodeHandler(IForgotPasswordService forgotPasswordService) : IRequestHandler<SendResetCodeRequest, string>
    {
        public async Task<string> Handle(SendResetCodeRequest request, CancellationToken cancellationToken)
        {
            
            return await forgotPasswordService.SendResetCode(request.Email);
        }
    }
}
