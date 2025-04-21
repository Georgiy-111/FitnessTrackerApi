using AutoMapper;
using FitnessTrackerApi.RequestModels;
using FitnessTrackerApi.DTOs.WorkoutType;
using FitnessTrackerApi.Models;

namespace FitnessTrackerApi.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<WorkoutTypeCreateRequestModel, WorkoutTypeCreateDto>()
            .ForMember(dest => dest.Name, 
                opt => opt.MapFrom(src => src.Name));

        CreateMap<WorkoutTypeCreateDto, WorkoutType>()
            .ForMember(dest => dest.Name, 
                opt => opt.MapFrom(src => src.Name));

        CreateMap<WorkoutType, WorkoutTypeDto>()
            .ForMember(dest => dest.Id, 
                opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, 
                opt => opt.MapFrom(src => src.Name));

        CreateMap<WorkoutTypeDto, WorkoutTypeCreateRequestModel>()
            .ForMember(dest => dest.Name, 
                opt => opt.MapFrom(src => src.Name));
    }
}