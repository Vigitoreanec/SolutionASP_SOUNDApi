using AutoMapper;
using Beautify.Application.Common.MappingProfile;
using Beautify.Application.Groups.Commands.CreateGroup;

namespace BeautifySOUND.Web.API;

public class CreateGroupDTO : IMapWith<CreateGroupCommand>
{
    public required string Title { get; set; }
    public string? Description { get; set; }
    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateGroupDTO, CreateGroupCommand>()
            .ForMember(groupCommand => groupCommand.Title,
            opt => opt.MapFrom(groupDTO => groupDTO.Title))
            .ForMember(groupCommand => groupCommand.Description,
            opt => opt.MapFrom(groupDTO => groupDTO.Description));
        
    }
}
