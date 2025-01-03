﻿using AutoMapper;
using Beautify.Application.Common.MappingProfile;
using Beautify.Domain;

namespace Beautify.Application.Groups.Queries.GetGroupDetails;

public class GroupDetailsViewModel : IMapWith<GroupNEW>
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }
    public void Mapping(Profile profile)
    {
        profile.CreateMap<GroupNEW, GroupDetailsViewModel>()
            //.ForMember(groupVM => groupVM.Id, opt => opt.MapFrom(groupVM => groupVM.Id))
            .ForMember(groupVM => groupVM.Title, opt => opt.MapFrom(groupVM => groupVM.Title))
            .ForMember(groupVM => groupVM.Description, opt => opt.MapFrom(groupVM => groupVM.Description));
    }
}
