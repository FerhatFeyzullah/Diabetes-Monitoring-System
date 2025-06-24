using DiabetesMonitoringSystem.Application.CQRS.DailyStatusFeatures.Commands.CreateDS;
using DiabetesMonitoringSystem.Application.CQRS.DailyStatusFeatures.Commands.UpdateDS;
using DiabetesMonitoringSystem.Application.CQRS.DailyStatusFeatures.Commands.UpdateDS_Diet;
using DiabetesMonitoringSystem.Application.CQRS.DailyStatusFeatures.Commands.UpdateDS_Exercise;
using DiabetesMonitoringSystem.Application.CQRS.DailyStatusFeatures.Queries.GetDS_ByDate;
using DiabetesMonitoringSystem.Application.CQRS.DailyStatusFeatures.Queries.GetDS_ByPatient;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DiabetesMonitoringSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DailyStatusesController(IMediator mediator) : ControllerBase
    {
        [HttpGet("GetDS_ByPatient")]
        public async Task<IActionResult> GetDS_ByPatient([FromQuery] GetDS_ByPatientRequest request)
        {
            var values = await mediator.Send(request);
            return Ok(values);
        }

        [HttpGet("GetDS_ByDate")]
        public async Task<IActionResult> GetDS_ByDate([FromQuery] GetDS_ByDateRequest request)
        {
            var values = await mediator.Send(request);
            return Ok(values);
        }

        [HttpPost("CreateDS")]
        public async Task<IActionResult> CreateDailyStatus([FromBody] CreateDS_Request request)
        {
            await mediator.Send(request);
            return Ok("Yeni Günlük Durum Eklendi");
        }

        [HttpPut("UpdateDS")]
        public async Task<IActionResult> DS_DietUpdate([FromBody] UpdateDSRequest request)
        {
            await mediator.Send(request);
            return Ok("Günlük Durum Diyet Bilgisi Güncellendi");
        }

        [HttpPut("UpdateDS_Diet")]
        public async Task<IActionResult> UpdateDS_Diet([FromQuery]UpdateDS_DietRequest request)
        {
            await mediator.Send(request);
            return Ok("Günlük Durum Diet Güncellemesi Başarılı.");
        }

        [HttpPut("UpdateDS_Exercise")]
        public async Task<IActionResult> UpdateDS_Exercise([FromQuery]UpdateDS_ExerciseRequest request)
        {
            await mediator.Send(request);
            return Ok("Günlük Durum Egzersiz Güncellemesi Başarılı.");
        }

    }
}
