using AutoMapper;
using AutoMapper.QueryableExtensions;
using Beautify.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Beautify.Application.Groups.Queries.GetGroupList;

public class GetGroupQueryHandler(IMapper mapper, IBeautifyDbContext beautifyDbContext) : IRequestHandler<GetGroupListQuery, GroupListViewModel>
{
    public async Task<GroupListViewModel> Handle(GetGroupListQuery request, CancellationToken cancellationToken)
    {
        var groups = await beautifyDbContext.Groups
            .ProjectTo<GroupLookupDTO>(mapper.ConfigurationProvider)
                   .Skip(request.CountSkipGroups)
                   .Take(request.CountTakeGroups)
                   .ToListAsync(cancellationToken);

        return new GroupListViewModel
        {
            Groups = groups
        };
    }
}
