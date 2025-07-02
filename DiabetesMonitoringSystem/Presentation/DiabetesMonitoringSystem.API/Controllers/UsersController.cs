using DiabetesMonitoringSystem.Application.CQRS.User.Commands.ChangePassword;
using DiabetesMonitoringSystem.Application.CQRS.User.Commands.CreateDoctor;
using DiabetesMonitoringSystem.Application.CQRS.User.Commands.CreateUser;
using DiabetesMonitoringSystem.Application.CQRS.User.Commands.ForgotPassword.ChangeForgotPassword;
using DiabetesMonitoringSystem.Application.CQRS.User.Commands.ForgotPassword.SendResetCode;
using DiabetesMonitoringSystem.Application.CQRS.User.Commands.ForgotPassword.VerifyResetCode;
using DiabetesMonitoringSystem.Application.CQRS.User.Commands.UploadProfilePhoto;
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
            var errorMessages = result.Errors.Select(e => e.Description).FirstOrDefault();
            return Ok(errorMessages);
            
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

        [HttpPost("UploadProfilePhoto")]
        public async Task<IActionResult> UploadProfilePhoto([FromForm] UploadProfilePhotoRequest request)
        {
            await mediator.Send(request);
            return Ok("Profil Fotoğrafı Yüklendi");
        }

        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequest request)
        {
            return Ok(await mediator.Send(request));
        }

        [HttpPost("SendResetCode")]
        public async Task<IActionResult> SendResetCode([FromBody] SendResetCodeRequest request)
        {
            await mediator.Send(request);
            return Ok("Şifre Sıfırlama Kodu Gönderildi");
        }

        [HttpPost("VerifyResetCode")]
        public async Task<IActionResult> VerifyResetCode([FromBody] VerifyResetCodeRequest request)
        {
            var result = await mediator.Send(request);
            if (result)
            {
                return Ok("Şifre Sıfırlama Kodu Doğrulandı");
            }
            else
            {
                return BadRequest("Kod Doğrulanamadı");
            }
        }

        [HttpPost("ChangeForgotPassword")]
        public async Task<IActionResult> ChangeForgotPassword([FromBody] ChangeForgotPasswordRequest request)
        {
            var result = await mediator.Send(request);
            if (result.Succeeded)
            {
                return Ok("Şifre Başarıyla Değiştirildi");
            }
            else
            {
                return BadRequest(new { errors = result.Errors.Select(e => e.Description) });
            }
        }
    }
}
