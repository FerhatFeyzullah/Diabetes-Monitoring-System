using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DiabetesMonitoringSystem.Application.CQRS.ExerciseFeatures.Commands.CreateExercise;
using DiabetesMonitoringSystem.Application.CQRS.ExerciseFeatures.Queries.GetAllExercise;
using DiabetesMonitoringSystem.Domain.Entities;

namespace DiabetesMonitoringSystem.Application.Mapping
{
    public class ExerciseMapping:Profile
    {
        public ExerciseMapping()
        {
            CreateMap<Exercise, CreateExerciseRequest>().ReverseMap();
            CreateMap<Exercise, GetAllExerciseResponse>().ReverseMap();
        }
    }
}
