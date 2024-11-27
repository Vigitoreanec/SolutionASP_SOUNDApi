using MediatR;

namespace Beautify.Application.Groups.Queries.GetGroupList;

public class GetGroupListQuery : IRequest<GroupListViewModel>
{
    public int CountSkipGroups { get; set; }
    public int CountTakeGroups { get; set; }

}
