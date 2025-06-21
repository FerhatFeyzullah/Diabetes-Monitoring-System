using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiabetesMonitoringSystem.Infrastructure.Interfaces;
using DiabetesMonitoringSystem.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;


namespace DiabetesMonitoringSystem.Infrastructure.ServiceExtension
{
    public static class InfrastructureExtension
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IMailService, MailService>();
        }
    }
}
