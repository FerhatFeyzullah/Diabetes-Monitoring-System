using DiabetesMonitoringSystem.Application.CQRS.BloodSugarFeatures.Commands.AddBloodSugar;
using DiabetesMonitoringSystem.Application.CQRS.BloodSugarFeatures.Queries.BloodSugarListByDate;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DiabetesMonitoringSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloodSugarsController(IMediator mediator) : ControllerBase
    {
        [HttpPost("CreateBloodSugar")]
        public async Task<IActionResult> CreateBloodSugar(AddBloodSugarRequest request)
        {
            return Ok(await mediator.Send(request));
        }

        [HttpGet("GetBloodSugarByPatientAndByDate")]
        public async Task<IActionResult> GetBloodSugarByPatientAndByDate([FromQuery]BloodSugarListByDateRequest request)
        {
            var values =  await mediator.Send(request);
            return Ok(values);
        }
    }
}
