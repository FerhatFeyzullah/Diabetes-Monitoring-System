using DiabetesMonitoringSystem.Application.CQRS.ExerciseFeatures.Commands.CreateExercise;
using DiabetesMonitoringSystem.Application.CQRS.ExerciseFeatures.Queries.GetAllExercise;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DiabetesMonitoringSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExercisesController(IMediator mediator) : ControllerBase
    {
        [HttpGet("GetAllExercises")]
        public async Task<IActionResult> GetAllExercises([FromQuery] GetAllExerciseRequest request)
        {
            return Ok(await mediator.Send(request));
        }
        [HttpPost("CreateExercise")]
        public async Task<IActionResult> CreateExercise([FromBody] CreateExerciseRequest request)
        {
            await mediator.Send(request);
            return Ok("Yeni Egzersiz Eklendi");
        }

    }
}
