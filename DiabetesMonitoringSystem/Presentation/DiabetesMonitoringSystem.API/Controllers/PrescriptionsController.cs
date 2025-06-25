
using DiabetesMonitoringSystem.Application.CQRS.PrescriptionFeatures.Commands.UpdatePrescription;
using DiabetesMonitoringSystem.Application.CQRS.PrescriptionFeatures.Queries.GetPrescriptionByPatient;
using DiabetesMonitoringSystem.Application.CQRS.PrescriptionFeatures.Queries.GetPrescriptionByPatientAndDate;
using DiabetesMonitoringSystem.Application.CQRS.PrescriptionFeatures.Queries.GetPrescriptionByPatientAndFilteredDate;
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
        public async Task<IActionResult> GetPrescriptionByPatient([FromQuery]GetPrescriptionByPatientRequest request) 
        {
            return Ok(await mediator.Send(request));
        }
        [HttpGet("GetPrescriptionByPatientAndDate")]
        public async Task<IActionResult> GetPrescriptionByPatientAndDate([FromQuery]GetPrescriptionByPatientAndDateRequest request)
        {
            return Ok(await mediator.Send(request));
        }
        [HttpGet("GetPrescriptionByPatientAndFilteredDate")]
        public async Task<IActionResult> GetPrescriptionByPatientAndFilteredDate([FromQuery] GetPrescriptionByPatientAndFilteredDateRequest request)
        {
            return Ok(await mediator.Send(request));
        }

        [HttpPut("UpdatePrescription")]
        public async Task<IActionResult> UpdatePrescription([FromBody]UpdatePrescriptionRequest request)
        {
            await mediator.Send(request);
            return Ok("Reçete güncelleme işlemi başarılı.");
        }

    }
}
