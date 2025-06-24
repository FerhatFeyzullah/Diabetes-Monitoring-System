using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiabetesMonitoringSystem.Domain.Entities;
using DiabetesMonitoringSystem.Domain.Enums;
using DiabetesMonitoringSystem.Persistence.DbContext;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DiabetesMonitoringSystem.Persistence.Services.EverydayService
{
    public class DailyAlertBackgroundService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;


        public DailyAlertBackgroundService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                // Gün sonuna (23:59) kadar bekle

                var now = DateTime.Now;
                var nextRun = now.TimeOfDay > new TimeSpan(23, 59, 0)
                            ? now.Date.AddDays(1).AddHours(23).AddMinutes(59)
                            : now.Date.AddHours(23).AddMinutes(59);

                var delay = nextRun - now;

                await Task.Delay(delay, stoppingToken);

                using var scope = _serviceProvider.CreateScope();
                var initializer = scope.ServiceProvider.GetRequiredService<DailyService>();
                await initializer.CheckDailyMeasurementsAsync(stoppingToken);
               

            }


        }

        
    }
}
