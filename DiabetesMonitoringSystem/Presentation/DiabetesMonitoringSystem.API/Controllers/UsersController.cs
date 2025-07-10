using DiabetesMonitoringSystem.Application.CQRS.User.Commands.ChangePassword;
using DiabetesMonitoringSystem.Application.CQRS.User.Commands.CreateDoctor;
using DiabetesMonitoringSystem.Application.CQRS.User.Commands.CreateUser;
using DiabetesMonitoringSystem.Application.CQRS.User.Commands.ForgotPassword.ChangeForgotPassword;
using DiabetesMonitoringSystem.Application.CQRS.User.Commands.ForgotPassword.SendResetCode;
using DiabetesMonitoringSystem.Application.CQRS.User.Commands.ForgotPassword.VerifyResetCode;
using DiabetesMonitoringSystem.Application.CQRS.User.Commands.RemoveProfilePhoto;
using DiabetesMonitoringSystem.Application.CQRS.User.Commands.UploadProfilePhoto;
using DiabetesMonitoringSystem.Application.CQRS.User.Queries.GetPatientWithDoctor;
using DiabetesMonitoringSystem.Application.CQRS.User.Queries.GetUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace DiabetesMonitoringSystem.API.Controllers
{
    [Authorize(Roles = "Doktor, Hasta")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IMediator mediator, IWebHostEnvironment _environment) : ControllerBase
    {


        [HttpGet("GetPatientsForDoctor")]
        public async Task<IActionResult> GetPatientForDoctor([FromQuery] GetPatientForDoctorRequest request)
        {
            return Ok(await mediator.Send(request));
        }

        [AllowAnonymous]
        [HttpGet("GetUser")]
        public async Task<IActionResult> GetUser([FromQuery] GetUserRequest request)
        {
            return Ok(await mediator.Send(request));
        }

        [HttpGet("ProfileImage/{photoId}")]
        public IActionResult GetProfileImage(string photoId)
        {
            if (string.IsNullOrWhiteSpace(photoId) || photoId.Contains(".."))
                return BadRequest("Geçersiz dosya adı.");

            var filePath = Path.Combine(_environment.WebRootPath, "upload", photoId);

            if (!System.IO.File.Exists(filePath))
                return NotFound();

            var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);

            var contentType = GetContentType(filePath); // dosya türünü dinamik ayarla

            Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
            Response.Headers["Pragma"] = "no-cache";
            Response.Headers["Expires"] = "0";


            return new FileStreamResult(stream, contentType);

        }

        private string GetContentType(string path)
        {
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return ext switch
            {
                ".jpg" => "image/jpeg",
                ".jpeg" => "image/jpeg",
                ".png" => "image/png",
                ".gif" => "image/gif",
                _ => "application/octet-stream"
            };
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

        [HttpPut("UploadProfilePhoto")]
        public async Task<IActionResult> UploadProfilePhoto([FromForm] UploadProfilePhotoRequest request)
        {
            return Ok(await mediator.Send(request));
        }

        [HttpPut("RemoveProfilePhoto/{id}")]
        public async Task<IActionResult> RemoveProfilePhoto(int id)
        {
            return Ok(await mediator.Send(new RemoveProfilePhotoRequest { AppUserId = id }));
        }

        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequest request)
        {
            return Ok(await mediator.Send(request));
        }

        [AllowAnonymous]
        [HttpPost("SendResetCode")]
        public async Task<IActionResult> SendResetCode([FromBody] SendResetCodeRequest request)
        {

            var result = await mediator.Send(request);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost("VerifyResetCode")]
        public async Task<IActionResult> VerifyResetCode([FromBody] VerifyResetCodeRequest request)
        {
          
                return Ok(await mediator.Send(request));         
        }

        [AllowAnonymous]
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
