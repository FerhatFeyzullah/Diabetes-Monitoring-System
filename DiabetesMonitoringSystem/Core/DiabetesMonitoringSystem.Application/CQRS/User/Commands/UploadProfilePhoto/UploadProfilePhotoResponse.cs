using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabetesMonitoringSystem.Application.CQRS.User.Commands.UploadProfilePhoto
{
    public class UploadProfilePhotoResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? ProfilePhotoId { get; set; }
    }
}
