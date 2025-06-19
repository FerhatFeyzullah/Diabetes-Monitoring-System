using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.User.Commands.CreateUser
{
    public class CreateUserRequest:IRequest<Unit>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int TC { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string? ProfilePhotoId { get; set; }
    }
}
