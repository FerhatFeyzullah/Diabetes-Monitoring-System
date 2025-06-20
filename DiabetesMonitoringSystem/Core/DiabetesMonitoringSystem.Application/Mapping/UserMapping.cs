﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DiabetesMonitoringSystem.Application.CQRS.User.Commands.CreateDoctor;
using DiabetesMonitoringSystem.Application.CQRS.User.Commands.CreateUser;
using DiabetesMonitoringSystem.Application.CQRS.User.Queries.GetPatientWithDoctor;
using DiabetesMonitoringSystem.Application.DTOs.UserDTOs;
using DiabetesMonitoringSystem.Domain.Entities;

namespace DiabetesMonitoringSystem.Application.Mapping
{
    public class UserMapping:Profile
    {
        public UserMapping()
        {
            CreateMap<AppUser, UserRegisterDto>().ReverseMap();
            CreateMap<UserRegisterDto, CreatePatientRequest>().ReverseMap();
            CreateMap<UserRegisterDto, CreateDoctorRequest>().ReverseMap();
            CreateMap<AppUser,GetPatientForDoctorResponse>().ReverseMap();
        }
    }
}
