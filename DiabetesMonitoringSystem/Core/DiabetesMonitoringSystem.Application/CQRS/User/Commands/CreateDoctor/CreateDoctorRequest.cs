using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiabetesMonitoringSystem.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace DiabetesMonitoringSystem.Application.CQRS.User.Commands.CreateDoctor
{
    public class CreateDoctorRequest:IRequest<IdentityResult>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TC { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        [Compare("Password",ErrorMessage ="Sifreler birbiri ile ayni degil")]
        public string ConfirmPassword { get; set; }
        public DateOnly BirthDate { get; set; }
        public Gender Gender { get; set; }
        public string? ProfilePhotoId { get; set; }

        
    }
}
