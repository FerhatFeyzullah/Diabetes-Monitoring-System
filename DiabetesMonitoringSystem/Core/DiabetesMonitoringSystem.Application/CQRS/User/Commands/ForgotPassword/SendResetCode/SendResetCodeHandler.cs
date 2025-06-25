using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiabetesMonitoringSystem.Application.Services;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.User.Commands.ForgotPassword.SendResetCode
{
    public class SendResetCodeHandler(IForgotPasswordService forgotPasswordService) : IRequestHandler<SendResetCodeRequest, Unit>
    {
        public async Task<Unit> Handle(SendResetCodeRequest request, CancellationToken cancellationToken)
        {
            await forgotPasswordService.SendResetCode(request.Email);
            return Unit.Value;
        }
    }
}
