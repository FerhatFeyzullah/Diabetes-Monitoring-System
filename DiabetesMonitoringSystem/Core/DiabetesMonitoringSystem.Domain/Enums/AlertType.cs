using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabetesMonitoringSystem.Domain.Enums
{
    public enum AlertType 
    {
        Emergency = 1,        
        FollowUp = 2,
        Monitoring = 3,
        MissingMeasurement = 4,
        InsufficientMeasurement = 5,
    }
}
