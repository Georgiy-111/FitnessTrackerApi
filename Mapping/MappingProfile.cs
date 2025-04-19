using AutoMapper;
using FitnessTrackerApi.RequestModels;
using FitnessTrackerApi.DTOs.WorkoutType;
using FitnessTrackerApi.Models;

namespace FitnessTrackerApi.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<WorkoutTypeCreateRequestModel, WorkoutTypeCreateDto>();
        
        CreateMap<WorkoutTypeCreateDto, WorkoutType>();
        
        CreateMap<WorkoutType, WorkoutTypeDto>();
        
        CreateMap<WorkoutTypeDto, WorkoutTypeCreateRequestModel>();
    }
}