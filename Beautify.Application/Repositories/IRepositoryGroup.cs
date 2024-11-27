using Beautify.Application.Groups.Queries.GetGroupDetails;
using Beautify.Application.Groups.Queries.GetGroupList;

namespace Beautify.Application.Repositories
{
    public interface IRepositoryGroup
    {
        Task<GroupListViewModel> GetGroupListRange(GetGroupListQuery request, CancellationToken cancellationToken);
        Task<GroupDetailsViewModel> GetGroupDetails(GetGroupDetailsQuery request, CancellationToken cancellationToken);
    }
}
