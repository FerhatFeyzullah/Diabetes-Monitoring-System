using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiabetesMonitoringSystem.Domain.Entities;
using DiabetesMonitoringSystem.Domain.Enums;

namespace DiabetesMonitoringSystem.Application.CQRS.User.Queries.GetPatientWithDoctor
{
    public class GetPatientForDoctorResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }        
        
    }
}
