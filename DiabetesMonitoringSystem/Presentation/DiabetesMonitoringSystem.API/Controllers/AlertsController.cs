using DiabetesMonitoringSystem.Application.CQRS.AlertFeatures.Queries.GetAlertByPatientAndAlertType;
using DiabetesMonitoringSystem.Application.CQRS.AlertFeatures.Queries.GetAlertsByPatient;
using DiabetesMonitoringSystem.Application.CQRS.AlertFeatures.Queries.GetAlertsByPatientAndDate;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DiabetesMonitoringSystem.API.Controllers
{
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
    }
}
