using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DiabetesMonitoringSystem.Application.Repositories;
using DiabetesMonitoringSystem.Domain.Entities;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.User.Queries.GetUser
{
    public class GetUserHandler(IReadRepository<AppUser> readRepository, IMapper mapper) : IRequestHandler<GetUserRequest, GetUserResponse>
    {
        public async Task<GetUserResponse> Handle(GetUserRequest request, CancellationToken cancellationToken)
        {
            var user = await readRepository.GetByIdAsync(request.AppUserId);
            return mapper.Map<GetUserResponse>(user);
        }
    }
}
