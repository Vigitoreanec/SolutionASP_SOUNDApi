using AutoMapper;
using Beautify.Application.Common.MappingProfile;
using Beautify.Application.Groups.Commands.UpdateGroup;

namespace BeautifySOUND.Web.API;

public class UpdateGroupDTO : IMapWith<UpdateGroupCommand>
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }
    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateGroupDTO, UpdateGroupCommand>()
            .ForMember(groupCommand => groupCommand.Id,
                opt => opt.MapFrom(groupDto => groupDto.Id))
            .ForMember(groupCommand => groupCommand.Title,
                opt => opt.MapFrom(groupDto => groupDto.Title))
            .ForMember(groupCommand => groupCommand.Description,
                opt => opt.MapFrom(groupDto => groupDto.Description));
    }
}
