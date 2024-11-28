using AutoMapper;
using Beautify.Application.Exceptions;
using Beautify.Application.Groups.Queries.GetGroupDetails;
using Beautify.Application.Groups.Queries.GetGroupList;
using Beautify.Application.Repositories;
using Beautify.Domain;
using Microsoft.EntityFrameworkCore;

namespace Beautify.PersistenceDb.Repositories;

public class RepositoryGroupEF(BeautifyDbContext beautifyDbContext, IMapper mapper) : IRepositoryGroup
{
    public async Task<GroupDetailsViewModel> GetGroupDetails(GetGroupDetailsQuery request, CancellationToken cancellationToken)
    {
        var group = await beautifyDbContext.Groups.FirstOrDefaultAsync(group => group.Id == request.Id, cancellationToken) ??
            throw new NotFoundException(nameof(GroupNEW), request.Id);

        return mapper.Map<GroupDetailsViewModel>(group);
    }

    public Task<GroupListViewModel> GetGroupListRange(GetGroupListQuery request, CancellationToken cancellationToken)
    {
        
        throw new NotImplementedException();
    }
}
