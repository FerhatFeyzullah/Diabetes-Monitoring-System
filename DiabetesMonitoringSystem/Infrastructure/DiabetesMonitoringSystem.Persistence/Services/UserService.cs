using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DiabetesMonitoringSystem.Application.DTOs.UserDTOs;
using DiabetesMonitoringSystem.Application.Services;
using DiabetesMonitoringSystem.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DiabetesMonitoringSystem.Persistence.Services
{
    public class UserService(UserManager<AppUser> usermanager,SignInManager<AppUser> signInManager,IJwtService jwtService,IMapper mapper) : IUserService
    {
        public async Task<IdentityResult> CreateDoctorAsync(UserRegisterDto userRegisterDto)
        {
            var user = mapper.Map<AppUser>(userRegisterDto);

            var result = await usermanager.CreateAsync(user, userRegisterDto.Password);

            if (result.Succeeded)
            {
                await usermanager.AddToRoleAsync(user, "Doktor");
                return result;
            }

            return result;
        }

        public async Task<IdentityResult> CreatePatientAsync(UserRegisterDto userRegisterDto)
        {
            var user = mapper.Map<AppUser>(userRegisterDto);

            var result = await usermanager.CreateAsync(user, userRegisterDto.Password);
            if (result.Succeeded)
            {
               await usermanager.AddToRoleAsync(user, "Hasta");
            }
           
            return result;
        }

        public async Task<string?> LoginAsync(UserLoginDto userLoginDto)
        {
            var user = await usermanager.Users.FirstOrDefaultAsync(u => u.TC == userLoginDto.TC);
            if (user == null)
                return null;

            var result = await signInManager.PasswordSignInAsync(user, userLoginDto.Password, false, false);
            if (!result.Succeeded)
            {
                return null;
            }
            var token = await jwtService.CreateTokenAsync(user);
            return token;
        }

        public async Task LogoutAsync()
        {
            await signInManager.SignOutAsync();
        }
    }
}
