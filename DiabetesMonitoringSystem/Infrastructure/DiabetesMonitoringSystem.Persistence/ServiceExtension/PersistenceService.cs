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
using DiabetesMonitoringSystem.Persistence.Services.EverydayService;
using DiabetesMonitoringSystem.Persistence.Services.EveryFiveMinutesService;
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
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IBloodSugarService, BloodSugarService>();
            services.AddScoped<IInsulinService, InsulinService>();  
            services.AddScoped<IAlertService, AlertService>();
            services.AddScoped<IDS_Service, DS_Service>();
            services.AddScoped<IPrescriptionService, PrescriptionService>();
            services.AddScoped<IForgotPasswordService, ForgotPasswordService>();


            services.AddScoped<DailyService>();
            services.AddHostedService<DailyBackgroundService>();
            services.AddHostedService<DailyAlertBackgroundService>();

            services.AddScoped<IJwtService, JwtService>();
            services.Configure<JwtTokenOptions>(cfg.GetSection("TokenOptions"));

            services.AddMemoryCache();


        }
    }
}
