using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DiabetesMonitoringSystem.Application.Services;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.User.Commands.RemoveProfilePhoto
{
    public class RemoveProfilePhotoHandler(IUserService userService,IMapper mapper) : IRequestHandler<RemoveProfilePhotoRequest, RemoveProfilePhotoResponse>
    {
        public async Task<RemoveProfilePhotoResponse> Handle(RemoveProfilePhotoRequest request, CancellationToken cancellationToken)
        {
            var user = await userService.RemoveImage(request.AppUserId);
            return mapper.Map<RemoveProfilePhotoResponse>(user);
        }
    }
}
