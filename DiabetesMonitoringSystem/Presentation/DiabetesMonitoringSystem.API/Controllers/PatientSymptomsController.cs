using DiabetesMonitoringSystem.Application.CQRS.PatientSymptomFeatures.Commands;
using DiabetesMonitoringSystem.Application.CQRS.PatientSymptomFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DiabetesMonitoringSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientSymptomsController(IMediator mediator) : ControllerBase
    {
        [HttpPost("CreatePatientSymptom")]
        public async Task<IActionResult> CreatePatientSymptom(CreatePatientSymptomRequest request) 
        {
            await mediator.Send(request);
            return Ok("Yeni Hasta Belirtisi Eklendi.");
        }

        [HttpGet("GetPatientSymptomsByPatient")]
        public async Task<IActionResult> GetPatientSymptomsByPatient([FromQuery]GetPS_ByPatientRequest request)
        {
            return Ok(await mediator.Send(request));
        }

    }
}
