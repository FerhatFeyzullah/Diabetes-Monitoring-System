using DiabetesMonitoringSystem.Application.CQRS.DailyStatusFeatures.Commands.CreateDS;
using DiabetesMonitoringSystem.Application.CQRS.DailyStatusFeatures.Commands.UpdateDS;
using DiabetesMonitoringSystem.Application.CQRS.DailyStatusFeatures.Commands.UpdateDS_DietNotOK;
using DiabetesMonitoringSystem.Application.CQRS.DailyStatusFeatures.Commands.UpdateDS_DietOK;
using DiabetesMonitoringSystem.Application.CQRS.DailyStatusFeatures.Commands.UpdateDS_ExerciseNotOk;
using DiabetesMonitoringSystem.Application.CQRS.DailyStatusFeatures.Commands.UpdateDS_ExerciseOk;
using DiabetesMonitoringSystem.Application.CQRS.DailyStatusFeatures.Queries.GetDS_ByPatientAndDate;
using DiabetesMonitoringSystem.Application.CQRS.DailyStatusFeatures.Queries.GetDS_ByPatientAndDateDaily;
using DiabetesMonitoringSystem.Application.CQRS.DailyStatusFeatures.Queries.GetDS_ByPatientAndFilteredDate;
using DiabetesMonitoringSystem.Application.CQRS.PrescriptionFeatures.Queries.GetPercentageOfDailyStatus;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DiabetesMonitoringSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DailyStatusesController(IMediator mediator) : ControllerBase
    {
        [HttpGet("GetDS_ByPatientAndDate")]
        public async Task<IActionResult> GetDS_ByPatientAndDate([FromQuery] GetDS_ByPatientAndDateRequest request)
        {
            return Ok(await mediator.Send(request));
        }

        [HttpGet("GetDS_ByPatientAndDateDaily")]
        public async Task<IActionResult> GetDS_ByPatientAndDateDaily([FromQuery] GetDS_ByPatientAndDateDailyRequest request)
        {
            return Ok(await mediator.Send(request));
        }

        [HttpGet("GetDS_ByPatientAndFilteredDate")]
        public async Task<IActionResult> GetDS_ByPatientAndFilteredDate([FromQuery] GetDS_ByPatientAndFilteredDateRequest request)
        {
            return Ok(await mediator.Send(request));
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
            return Ok("Günlük Durum  Bilgisi Güncellendi");
        }

        [HttpPut("UpdateDS_DietOk")]
        public async Task<IActionResult> UpdateDS_DietOk([FromBody] UpdateDS_DietOkRequest request)
        {
            await mediator.Send(request);
            return Ok("Günlük Durum Diet Güncellemesi Başarılı.");
        }

        [HttpPut("UpdateDS_DietNotOk")]
        public async Task<IActionResult> UpdateDS_DietNotOk([FromBody] UpdateDS_DietNotOkRequest request)
        {
            await mediator.Send(request);
            return Ok("Günlük Durum Diet Güncellemesi Başarılı.");
        }

        [HttpPut("UpdateDS_ExerciseOk")]
        public async Task<IActionResult> UpdateDS_ExerciseOk([FromBody]UpdateDS_ExerciseOkRequest request)
        {
            await mediator.Send(request);
            return Ok("Günlük Durum Egzersiz Güncellemesi Başarılı.");
        }

        [HttpPut("UpdateDS_ExerciseNotOk")]
        public async Task<IActionResult> UpdateDS_ExerciseNotOk([FromBody] UpdateDS_ExerciseNotOkRequest request)
        {
            await mediator.Send(request);
            return Ok("Günlük Durum Egzersiz Güncellemesi Başarılı.");
        }

        [HttpGet("GetPercentage")]
        public async Task<IActionResult> GetPercentage([FromQuery] GetPercentageOfPrescriptionRequest request)
        {
            return Ok(await mediator.Send(request));
        }

    }
}
