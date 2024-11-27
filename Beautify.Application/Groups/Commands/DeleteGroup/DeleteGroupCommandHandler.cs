
using Beautify.Application.Exceptions;
using Beautify.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Xml;

namespace Beautify.Application.Groups.Commands.DeleteGroup;

public class DeleteGroupCommandHandler(IBeautifyDbContext beautifyDbContext) : IRequestHandler<DeleteGroupCommand>
{
    public async Task Handle(DeleteGroupCommand request, CancellationToken cancellationToken)
    {
        var group = await beautifyDbContext.Groups.FirstOrDefaultAsync(group => group.Id == request.Id, cancellationToken);
        if (group is null)
        {
            throw new NotFoundException(nameof(group), request.Id);
        }
        beautifyDbContext.Groups.Remove(group);
        await beautifyDbContext.SaveChangesAsync(cancellationToken);
    }
}
