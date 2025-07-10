
using DiabetesMonitoringSystem.Application.CQRS.PrescriptionFeatures.Commands.UpdatePrescription;
using DiabetesMonitoringSystem.Application.CQRS.PrescriptionFeatures.Queries.GetPrescriptionByPatientAndDate;
using DiabetesMonitoringSystem.Application.CQRS.PrescriptionFeatures.Queries.GetPrescriptionByPatientAndDateDaily;
using DiabetesMonitoringSystem.Application.CQRS.PrescriptionFeatures.Queries.GetPrescriptionByPatientAndFilteredDate;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DiabetesMonitoringSystem.API.Controllers
{
    [Authorize(Roles = "Doktor, Hasta")]
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionsController(IMediator mediator) : ControllerBase
    {
        [HttpGet("GetPrescriptionByPatientAndDate")]
        public async Task<IActionResult> GetPrescriptionByPatientAndDate([FromQuery]GetPrescriptionByPatientAndDateRequest request) 
        {
            return Ok(await mediator.Send(request));
        }
        [HttpGet("GetPrescriptionByPatientAndDateDaily")]
        public async Task<IActionResult> GetPrescriptionByPatientAndDateDaily([FromQuery]GetPrescriptionByPatientAndDateDailyRequest request)
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
