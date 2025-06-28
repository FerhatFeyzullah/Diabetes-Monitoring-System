using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabetesMonitoringSystem.Application.CQRS.User.Commands.LoginTheSystem
{
    public class LoginTheSystemResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
