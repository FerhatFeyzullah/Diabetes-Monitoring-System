using DiabetesMonitoringSystem.Application.CQRS.User.Commands.CreateDoctor;
using DiabetesMonitoringSystem.Application.CQRS.User.Commands.CreateUser;
using DiabetesMonitoringSystem.Application.CQRS.User.Queries.GetPatientWithDoctor;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DiabetesMonitoringSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IMediator mediator) : ControllerBase
    {

        [HttpGet("GetPatientsForDoctor")]
        public async Task<IActionResult> GetPatientForDoctor([FromQuery] GetPatientForDoctorRequest request)
        {
            return Ok(await mediator.Send(request));
        }

        [HttpPost("CreatePatient")]
        public async Task<IActionResult> CreatePatient(CreatePatientRequest request)
        {
            var result = await mediator.Send(request);
            if (result.Succeeded)
            {
                return Ok("Yeni Hasta Kaydi Yapildi");
            }
            else
            {
                return BadRequest(new { errors = result.Errors.Select(e => e.Description) });
            }
        }

        [HttpPost("CreateDoctor")]
        public async Task<IActionResult> CreateDoctor(CreateDoctorRequest request)
        {
            var result = await mediator.Send(request);
            if (result.Succeeded)
            {
                return Ok("Yeni Doktor Kaydi Yapildi");
            }
            else
            {
                return BadRequest(new { errors = result.Errors.Select(e => e.Description) });
            }
        }
    }
}
