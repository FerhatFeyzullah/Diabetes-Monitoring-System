using DiabetesMonitoringSystem.Application.CQRS.AlertFeatures.Commands.ReadAlert;
using DiabetesMonitoringSystem.Application.CQRS.AlertFeatures.Queries.GetAlertByPatientAndAlertType;
using DiabetesMonitoringSystem.Application.CQRS.AlertFeatures.Queries.GetAlertsByPatient;
using DiabetesMonitoringSystem.Application.CQRS.AlertFeatures.Queries.GetAlertsByPatientAndDate;
using DiabetesMonitoringSystem.Application.CQRS.AlertFeatures.Queries.GetAlertsByPatientAndDateAndType;
using DiabetesMonitoringSystem.Application.CQRS.AlertFeatures.Queries.GetAlertsDaily;
using DiabetesMonitoringSystem.Application.CQRS.AlertFeatures.Queries.GetUnReadAlertsCount;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DiabetesMonitoringSystem.API.Controllers
{
    [Authorize(Roles ="Doktor")]
    [Route("api/[controller]")]
    [ApiController]
    public class AlertsController(IMediator mediator) : ControllerBase
    {
        [HttpGet("GetAlertsByPatient")]
        public async Task<IActionResult> GetAlertsByPatient([FromQuery]GetAlertByPatientRequest request) 
        {          
            return Ok(await mediator.Send(request));
        }

        [HttpGet("GetAlertsByPatientAndDate")]
        public async Task<IActionResult> GetAlertsByPatientAndDate([FromQuery] GetAlertsByPatientAndDateRequest request) 
        {
            return Ok(await mediator.Send(request));
        }

        [HttpGet("GetAlertByPatientAndAlertType")]
        public async Task<IActionResult> GetAlertByPatientAndAlertType([FromQuery]GetAlertByPatientAndAlertTypeRequest request)
        {
            return Ok(await mediator.Send(request));
        }

        [HttpGet("GetAlertsByPatientAndDateAndType")]
        public async Task<IActionResult> GetAlertsByPatientAndDateAndType([FromQuery] GetAlertsByPatientAndDateAndTypeRequest request)
        {
            return Ok(await mediator.Send(request));
        }

        [HttpGet("GetAlertsDaily")]
        public async Task<IActionResult> GetAlertsDaily([FromQuery] GetAlertsDailyRequest request)
        {
            return Ok(await mediator.Send(request));
        }

        [HttpGet("GetUnReadAlertsCount")]
        public async Task<IActionResult> GetUnReadAlertsCount([FromQuery] GetUnReadAlertsCountRequest request)
        {
            return Ok(await mediator.Send(request));
        }

        [HttpPut("ReadingAlert")]
        public async Task<IActionResult> ReadingAlert([FromBody] ReadAlertRequest request)
        {
            return Ok(await mediator.Send(request));
        }
    }
}
