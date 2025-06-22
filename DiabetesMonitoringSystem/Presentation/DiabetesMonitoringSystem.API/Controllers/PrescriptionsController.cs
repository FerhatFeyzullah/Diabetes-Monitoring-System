using DiabetesMonitoringSystem.Application.CQRS.PrescriptionFeatures.Commands;
using DiabetesMonitoringSystem.Application.CQRS.PrescriptionFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DiabetesMonitoringSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionsController(IMediator mediator) : ControllerBase
    {
        [HttpGet("GetPrescriptionByPatient")]
        public async Task<IActionResult> GetPrescriptionByPatient([FromQuery] GetPrescriptionByPatientRequest request)
        {
            return Ok(await mediator.Send(request));
        }
        [HttpPost("CreatePrescription")]
        public async Task<IActionResult> CreatePrescription([FromBody] CreatePrescriptionRequest request)
        {
            await mediator.Send(request);
            return Ok("Yeni Reçete Eklendi");
        }
    }
}
