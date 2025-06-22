using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using DiabetesMonitoringSystem.Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace DiabetesMonitoringSystem.Domain.Entities
{
    public class AppUser: IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TC { get; set; }
        public DateOnly BirthDate { get; set; }
        public Gender Gender { get; set; }        
        public string? ProfilePhotoId { get; set; }

        public int? DoctorId { get; set; }
        public AppUser Doctor { get; set; }
    }
}
