using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiabetesMonitoringSystem.Application.DTOs.UserDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace DiabetesMonitoringSystem.Application.Services
{
    public interface IUserService
    {

        Task<IdentityResult> CreatePatientAsync(PatientRegisterDto userRegisterDto);

        Task<IdentityResult> CreateDoctorAsync(DoctorRegisterDto userRegisterDto);

        Task<string?> LoginAsync(UserLoginDto userLoginDto);

        Task LogoutAsync();

        Task UploadImage(int patientId,IFormFile image);

        Task<IdentityResult> ChangePassword(int appUserId, string oldPass,string newPass,string confNewPass);

        Task<IdentityResult> ChangeForgotPassword(string email, string newPass, string confNewPass);

        
    }
}
