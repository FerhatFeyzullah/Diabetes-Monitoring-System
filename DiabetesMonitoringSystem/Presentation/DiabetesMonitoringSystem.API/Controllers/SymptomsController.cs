using DiabetesMonitoringSystem.Application.CQRS.SymptomFeatures.Queries.GetAllSymptom;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DiabetesMonitoringSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SymptomsController(IMediator mediator) : ControllerBase
    {
        [HttpGet("GetAllSymptoms")]
        public async Task<IActionResult> GetAllSymptoms([FromQuery]GetAllSymptomRequest request) 
        {
            return Ok(await mediator.Send(request));
        }
    }
}
