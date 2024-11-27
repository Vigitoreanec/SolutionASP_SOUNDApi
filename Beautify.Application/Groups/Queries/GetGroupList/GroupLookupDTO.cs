using Beautify.Domain;
using Beautify.Application.Common.MappingProfile;
using AutoMapper;

namespace Beautify.Application.Groups.Queries.GetGroupList;

public class GroupLookupDTO : IMapWith<Group>
{
    public int Id { get; set; }
    public string Title { get; set; }
    public void Mapping (Profile profile) // логика мапинга
    {
        // от Группы к сущность поиска -> (представление)
        profile.CreateMap<Group, GroupLookupDTO>()
            .ForMember(group => group.Id,                   // мапинг по ID
            opt => opt.MapFrom(group => group.Id))          // куда мапится
            .ForMember(group => group.Title,                // мапинг по TITLE
            opt => opt.MapFrom(group => group.Title));      // куда мапится
    }
}
