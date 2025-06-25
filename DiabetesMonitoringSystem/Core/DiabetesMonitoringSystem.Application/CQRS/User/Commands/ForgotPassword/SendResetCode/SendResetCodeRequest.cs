using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.User.Commands.ForgotPassword.SendResetCode
{
    public class SendResetCodeRequest:IRequest<Unit>
    {
        public string Email { get; set; }
    }
}
