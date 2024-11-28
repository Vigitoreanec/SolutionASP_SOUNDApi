
using Beautify.Application.Exceptions;
using Beautify.Application.Interfaces;
using Beautify.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Beautify.Application.Groups.Commands.UpdateGroup;

public class UpdateGroupCommandHandler(IBeautifyDbContext beautifyDbContext) : IRequestHandler<UpdateGroupCommand>
{
    public async Task Handle(UpdateGroupCommand request, CancellationToken cancellationToken)
    {
        var group = await beautifyDbContext.Groups.FirstOrDefaultAsync(group => group.Id == request.Id, cancellationToken)
            ?? throw new NotFoundException(nameof(GroupNEW), request.Id);

        group.Title = request.Title;
        group.Description = request.Description;

        await beautifyDbContext.SaveChangesAsync(cancellationToken);
    }
}
