﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiabetesMonitoringSystem.Application.DTOs.UserDTOs;
using Microsoft.AspNetCore.Identity;

namespace DiabetesMonitoringSystem.Application.Services
{
    public interface IUserService
    {

        Task<IdentityResult> CreatePatientAsync(UserRegisterDto userRegisterDto);

        Task<IdentityResult> CreateDoctorAsync(UserRegisterDto userRegisterDto);

        Task<string?> LoginAsync(UserLoginDto userLoginDto);

        Task LogoutAsync();
    }
}
