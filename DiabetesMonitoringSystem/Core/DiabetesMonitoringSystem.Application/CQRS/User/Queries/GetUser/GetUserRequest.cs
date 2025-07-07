using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.User.Queries.GetUser
{
    public class GetUserRequest:IRequest<GetUserResponse>
    {
        public int AppUserId { get; set; }
    }
}
