using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiabetesMonitoringSystem.Application.Services;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.User.Commands.UploadProfilePhoto
{
    public class UploadProfilePhotoHandler(IUserService userService) : IRequestHandler<UploadProfilePhotoRequest, Unit>
    {
        public async Task<Unit> Handle(UploadProfilePhotoRequest request, CancellationToken cancellationToken)
        {
            await userService.UploadImage(request.AppUserId, request.Image);
            return Unit.Value;
        }
    }
}
