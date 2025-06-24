using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DiabetesMonitoringSystem.Persistence.Services.EveryFiveMinutesService
{
    public class DailyBackgroundService:BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        

        public DailyBackgroundService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {               
                    using var scope = _serviceProvider.CreateScope();
                    var initializer = scope.ServiceProvider.GetRequiredService<DailyService>();
                    await initializer.DailyCreateDS_Async(stoppingToken);
                
                await Task.Delay(TimeSpan.FromMinutes(5), stoppingToken);
           }
        }
    }
}
