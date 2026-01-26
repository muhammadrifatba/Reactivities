using System;
using Application.Activities.DTOs;
using AutoMapper;
using Domain;

namespace Application.Core;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Activity, Activity>();
        CreateMap<CreateActivityDto, Activity>().ReverseMap();
    }
}
