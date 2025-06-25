using DiabetesMonitoringSystem.Application.CQRS.InsulinFeatures.Queries.GetInsulinByPatientAndGroupedByDate;
using DiabetesMonitoringSystem.Application.CQRS.InsulinFeatures.Queries.GetInsulinByPatientAndGroupedByFilteredDate;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DiabetesMonitoringSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsulinsController(IMediator mediator) : ControllerBase
    {
        [HttpGet("GetInsulinByPatientAndGroupedByDate")]
        public async Task<IActionResult> GetInsulinByPatientAndGroupedByDate([FromQuery] GetInsulinByPatientAndGroupedByDateRequest request)
        {
            return Ok(await mediator.Send(request));
        }

        [HttpGet("GetInsulinByPatientAndGroupedByFilteredDate")]
        public async Task<IActionResult> GetInsulinByPatientAndGroupedByFilteredDate([FromQuery] GetInsulinByPatientAndGroupedByFilteredDateRequest request)
        {
            return Ok(await mediator.Send(request));

        }
    }
}
