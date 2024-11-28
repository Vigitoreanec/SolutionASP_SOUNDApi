using AutoMapper;
using Beautify.Application.Exceptions;
using Beautify.Application.Interfaces;
using Beautify.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Beautify.Application.Groups.Queries.GetGroupDetails;

public class GetGroupDetailsQueryHandler(IBeautifyDbContext beautifyDbContext, IMapper mapper) : IRequestHandler<GetGroupDetailsQuery, GroupDetailsViewModel>
{
    public async Task<GroupDetailsViewModel> Handle(GetGroupDetailsQuery request, CancellationToken cancellationToken)
    {
        var group = await beautifyDbContext.Groups.FirstOrDefaultAsync(group => group.Id == request.Id, cancellationToken) ??
            throw new NotFoundException(nameof(Group),request.Id);  

        return mapper.Map<GroupDetailsViewModel>(group);
    }
}
