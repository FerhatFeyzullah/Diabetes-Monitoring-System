using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DiabetesMonitoringSystem.Application.CQRS.User.Commands.CreateDoctor;
using DiabetesMonitoringSystem.Application.CQRS.User.Commands.CreateUser;
using DiabetesMonitoringSystem.Application.CQRS.User.Commands.LoginTheSystem;
using DiabetesMonitoringSystem.Application.CQRS.User.Commands.RemoveProfilePhoto;
using DiabetesMonitoringSystem.Application.CQRS.User.Commands.UploadProfilePhoto;
using DiabetesMonitoringSystem.Application.CQRS.User.Queries.GetPatientWithDoctor;
using DiabetesMonitoringSystem.Application.CQRS.User.Queries.GetUser;
using DiabetesMonitoringSystem.Application.DTOs.UserDTOs;
using DiabetesMonitoringSystem.Domain.Entities;

namespace DiabetesMonitoringSystem.Application.Mapping
{
    public class UserMapping:Profile
    {
        public UserMapping()
        {
            CreateMap<AppUser, PatientRegisterDto>().ReverseMap();
            CreateMap<AppUser, DoctorRegisterDto>().ReverseMap();
            CreateMap<AppUser, ResultUserDto>().ReverseMap();

            CreateMap<AppUser,GetPatientForDoctorResponse>().ReverseMap();
            CreateMap<AppUser, GetUserResponse>().ReverseMap();
            CreateMap<AppUser, UploadProfilePhotoResponse>().ReverseMap();
            CreateMap<AppUser, RemoveProfilePhotoResponse>().ReverseMap();

            CreateMap<PatientRegisterDto, CreatePatientRequest>().ReverseMap();
            CreateMap<DoctorRegisterDto, CreateDoctorRequest>().ReverseMap();
            

            CreateMap<LoginTheSystemRequest, UserLoginDto>().ReverseMap();
            CreateMap<LoginTheSystemResponse, UserLoginResponseDto>().ReverseMap();
        }
    }
}
