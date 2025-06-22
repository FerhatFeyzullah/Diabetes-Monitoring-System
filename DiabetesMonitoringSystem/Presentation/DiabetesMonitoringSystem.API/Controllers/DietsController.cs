using DiabetesMonitoringSystem.Application.CQRS.DietFeatures.Commands;
using DiabetesMonitoringSystem.Application.CQRS.DietFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DiabetesMonitoringSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DietsController(IMediator mediator) : ControllerBase
    {
        [HttpGet("GetAllDiets")]
        public async Task<IActionResult> GetAllDiets([FromQuery]GetAllDietRequest request)
        {
            return Ok(await mediator.Send(request));
        }
        [HttpPost("CreateDiet")]
        public async Task<IActionResult> CreateDiet([FromBody] CreateDietRequest request)
        {
            await mediator.Send(request);
            return Ok("Yeni Diet Eklendi");
        }
    }
}
