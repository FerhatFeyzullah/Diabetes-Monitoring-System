using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiabetesMonitoringSystem.Application.DTOs.UserDTOs;
using DiabetesMonitoringSystem.Application.Services;
using DiabetesMonitoringSystem.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DiabetesMonitoringSystem.Persistence.Services
{
    public class UserService(UserManager<AppUser> usermanager,SignInManager<AppUser> signInManager,IJwtService jwtService) : IUserService
    {
        public async Task<IdentityResult> CreateUserAsync(UserRegisterDto userRegisterDto)
        {
            var user = new AppUser
            {
                FirstName = userRegisterDto.FirstName,
                LastName = userRegisterDto.LastName,
                Email = userRegisterDto.Email,
                TC = userRegisterDto.TC,
                Gender = userRegisterDto.Gender,
                BirthDate = userRegisterDto.BirthDate,
                UserName = userRegisterDto.UserName,
            };

            var result = await usermanager.CreateAsync(user, userRegisterDto.Password);
            if (!result.Succeeded)
            {
                // HATALARI LOG'LAMA (GEÇİCİ OLARAK)
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new Exception($"Kayıt Başarısız: {errors}");
            }

            await usermanager.AddToRoleAsync(user, "Hasta");
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

        public Task LogoutAsync()
        {
            throw new NotImplementedException();
        }
    }
}
