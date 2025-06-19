using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DiabetesMonitoringSystem.Application.Mapping;
using DiabetesMonitoringSystem.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DiabetesMonitoringSystem.Application.ServiceExtension
{
    public static class ApplicationExtension
    {
        public static void AddApplicationServices(this IServiceCollection services) 
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
            services.AddAutoMapper(assembly);

           // services.AddScoped<IUserService, UserService>();



        }
    }
}
