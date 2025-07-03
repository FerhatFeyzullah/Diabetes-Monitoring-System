using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabetesMonitoringSystem.Application.Services
{
    public interface IForgotPasswordService
    {
        Task<string> SendResetCode(string email);

        Task<bool> VerifyResetCode(string email, string code);
    }
}
