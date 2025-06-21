using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.User.Commands.LoginTheSystem
{
    public class LoginTheSystemRequest:IRequest<string>
    {
        public string TC { get; set; }
        public string Password { get; set; }
    }
}
