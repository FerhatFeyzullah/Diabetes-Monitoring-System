using DiabetesMonitoringSystem.Application.CQRS.User.Commands.CreateUser;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DiabetesMonitoringSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserRequest request)
        {
            await mediator.Send(request);
            return Ok("Yeni Hasta Kaydi Yapildi");
        }
    }
}
