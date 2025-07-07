using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DiabetesMonitoringSystem.Application.Services;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.User.Commands.UploadProfilePhoto
{
    public class UploadProfilePhotoHandler(IUserService userService,IMapper mapper) : IRequestHandler<UploadProfilePhotoRequest, UploadProfilePhotoResponse>
    {
        public async Task<UploadProfilePhotoResponse> Handle(UploadProfilePhotoRequest request, CancellationToken cancellationToken)
        {
            var user = await userService.UploadImage(request.AppUserId, request.Image);
            return mapper.Map<UploadProfilePhotoResponse>(user);
        }
    }
}
