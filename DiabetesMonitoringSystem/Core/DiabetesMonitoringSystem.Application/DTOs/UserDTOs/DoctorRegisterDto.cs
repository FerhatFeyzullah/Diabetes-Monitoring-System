﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiabetesMonitoringSystem.Domain.Enums;

namespace DiabetesMonitoringSystem.Application.DTOs.UserDTOs
{
    public class DoctorRegisterDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TC { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public DateOnly BirthDate { get; set; }
        public Gender Gender { get; set; }
        public string? ProfilePhotoId { get; set; }

    }
}
