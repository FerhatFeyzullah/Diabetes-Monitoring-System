using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace DiabetesMonitoringSystem.Application.CQRS.User.Commands.ChangePassword
{
    public class ChangePasswordRequest:IRequest<string>
    {
        public int AppUserId { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmNewPassword { get; set; }
    }
}
