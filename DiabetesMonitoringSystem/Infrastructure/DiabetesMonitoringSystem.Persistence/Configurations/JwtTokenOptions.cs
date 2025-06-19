using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabetesMonitoringSystem.Persistence.Configurations
{
    public class JwtTokenOptions
    {
        public string Issuer { get; set; } //api.diabetesmonitoring.com
        public string Audience { get; set; } //www.diabetesmonitoring.com
        public string Key { get; set; }
        public int ExpireInMinutes { get; set; }
    }
}
