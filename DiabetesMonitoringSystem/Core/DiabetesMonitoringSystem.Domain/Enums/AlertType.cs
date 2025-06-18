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
        Normal = 2,
        FollowUp = 3,
        Monitoring = 4,
        EmergencyIntervention = 5,
        MissingMeasurement = 6,
        InsufficientMeasurement = 7,
    }
}
