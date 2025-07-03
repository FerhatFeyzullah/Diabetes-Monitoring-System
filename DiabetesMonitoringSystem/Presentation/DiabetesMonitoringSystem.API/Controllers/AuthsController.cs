using System.Security.Claims;
using DiabetesMonitoringSystem.Application.CQRS.User.Commands.LoginTheSystem;
using DiabetesMonitoringSystem.Application.CQRS.User.Commands.LogoutTheSystem;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
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

            var result = await mediator.Send(request);

            if (result.Success) 
            {
                Response.Cookies.Append("MyAuthCookie", result.Message, new CookieOptions
                {
                    HttpOnly = true,
                    SameSite = SameSiteMode.None,
                    Secure = true,
                    Expires = DateTime.UtcNow.AddHours(1)
                });
            }
            return Ok(result);



        }

        [Authorize]
        [HttpGet("me")]
        public IActionResult GetCurrentUser()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var role = User.FindFirst(ClaimTypes.Role)?.Value;

            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(role))
            {
                return Unauthorized();
            }

            // İstersen buraya kullanıcı detayları çekilebilir.

            return Ok(new
            {
                UserId = userId,
                Role = role
            });
        }

        [HttpPost("Logout")]
        public async Task<IActionResult> Logout(LogoutTheSystemRequest request)
        {
            Response.Cookies.Append("MyAuthCookie", "", new CookieOptions
            {
                HttpOnly = true,
                SameSite = SameSiteMode.None,
                Secure = true,
                Expires = DateTime.UtcNow.AddHours(1)
            });
            await mediator.Send(request);
            return Ok();
        }
    }
}
