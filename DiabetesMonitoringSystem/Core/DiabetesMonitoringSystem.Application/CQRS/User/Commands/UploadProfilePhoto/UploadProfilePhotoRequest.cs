using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace DiabetesMonitoringSystem.Application.CQRS.User.Commands.UploadProfilePhoto
{
    public class UploadProfilePhotoRequest:IRequest<UploadProfilePhotoResponse>
    {
        public IFormFile Image { get; set; }
        public int AppUserId { get; set; }
    }
}
