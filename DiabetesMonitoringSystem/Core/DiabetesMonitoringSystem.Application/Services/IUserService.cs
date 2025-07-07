using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiabetesMonitoringSystem.Application.DTOs.UserDTOs;
using DiabetesMonitoringSystem.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace DiabetesMonitoringSystem.Application.Services
{
    public interface IUserService
    {

        Task<IdentityResult> CreatePatientAsync(PatientRegisterDto userRegisterDto);

        Task<IdentityResult> CreateDoctorAsync(DoctorRegisterDto userRegisterDto);

        Task<UserLoginResponseDto> LoginAsync(UserLoginDto userLoginDto);

        Task LogoutAsync();

        Task<AppUser>UploadImage(int patientId,IFormFile image);
        Task<AppUser>RemoveImage(int patientId);

        Task<string> ChangePassword(int appUserId, string oldPass,string newPass,string confNewPass);

        Task<IdentityResult> ChangeForgotPassword(string email, string newPass, string confNewPass);

        
    }
}
