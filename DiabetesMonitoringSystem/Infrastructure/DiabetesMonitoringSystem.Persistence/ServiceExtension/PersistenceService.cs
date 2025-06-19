using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiabetesMonitoringSystem.Application.Repositories;
using DiabetesMonitoringSystem.Application.Services;
using DiabetesMonitoringSystem.Persistence.Configurations;
using DiabetesMonitoringSystem.Persistence.Repositories;
using DiabetesMonitoringSystem.Persistence.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DiabetesMonitoringSystem.Persistence.ServiceExtension
{
    public static class PersistenceService
    {

        public static void AddPersistenceServices(this IServiceCollection services,IConfiguration cfg)
        {
            services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
            services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));

            services.AddScoped<IJwtService, JwtService>();
            services.Configure<JwtTokenOptions>(cfg.GetSection("TokenOptions"));
        }
    }
}
