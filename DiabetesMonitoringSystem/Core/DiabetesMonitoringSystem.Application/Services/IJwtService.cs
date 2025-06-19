using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiabetesMonitoringSystem.Domain.Entities;

namespace DiabetesMonitoringSystem.Application.Services
{
    public interface IJwtService
    {
        Task<string> CreateTokenAsync(AppUser user);
    }
}
