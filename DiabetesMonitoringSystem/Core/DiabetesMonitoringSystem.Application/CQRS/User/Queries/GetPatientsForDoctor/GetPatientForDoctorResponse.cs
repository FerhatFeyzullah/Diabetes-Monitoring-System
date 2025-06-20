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
        public string FirstName { get; set; }
        public string LastName { get; set; }        
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        
    }
}
