using DiabetesMonitoringSystem.Application.CQRS.BloodSugarFeatures.Commands.AddBloodSugar;
using DiabetesMonitoringSystem.Application.CQRS.BloodSugarFeatures.Queries.GetBS_ByPatientAndGroupedByDate;
using DiabetesMonitoringSystem.Application.CQRS.BloodSugarFeatures.Queries.GetBS_ByPatientAndGroupedByDateDaily;
using DiabetesMonitoringSystem.Application.CQRS.BloodSugarFeatures.Queries.GetBS_ByPatientAndGroupedByFilteredDate;
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

        [HttpGet("GetBS_ByPatientAndGroupedByDateDaily")]
        public async Task<IActionResult> GetBS_ByPatientAndGroupedByDateDaily([FromQuery] GetBS_ByPatientAndGroupedByDateDailyRequest request)
        {
            return Ok(await mediator.Send(request));
        }

        [HttpGet("GetBS_ByPatientAndGroupedByDate")]
        public async Task<IActionResult> GetBS_ByPatientAndGroupedByDate([FromQuery] BloodSugarListByDateRequest request)
        {
            return Ok(await mediator.Send(request));
        }

        [HttpGet("GetBS_ByPatientAndGroupedByFilteredDate")]
        public async Task<IActionResult> GetBS_ByPatientAndGroupedByFilteredDate([FromQuery] GetBS_ByPatientAndGroupedByFilteredDateRequest request)
        {
            return Ok(await mediator.Send(request));

        }
    }
}
