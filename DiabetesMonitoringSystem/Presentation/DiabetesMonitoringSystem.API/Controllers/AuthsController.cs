using DiabetesMonitoringSystem.Application.CQRS.User.Commands.LoginTheSystem;
using DiabetesMonitoringSystem.Application.CQRS.User.Commands.LogoutTheSystem;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DiabetesMonitoringSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController(IMediator mediator) : ControllerBase
    {
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginTheSystemRequest request)
        {
            return Ok(await mediator.Send(request));
        }

        [HttpPost("Logout")]
        public async Task<IActionResult> Logout(LogoutTheSystemRequest request)
        {
            return Ok(await mediator.Send(request));
        }
    }
}
