
using Beautify.Application.Exceptions;
using Beautify.Application.Interfaces;
using Beautify.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace Beautify.Application.Groups.Commands.DeleteGroup;

public class DeleteGroupCommandHandler(IBeautifyDbContext beautifyDbContext) : IRequestHandler<DeleteGroupCommand>
{
    public async Task Handle(DeleteGroupCommand request, CancellationToken cancellationToken)
    {
        var group = await beautifyDbContext.Groups.FirstOrDefaultAsync(group => group.Id == request.Id, cancellationToken);
        if (group is null)
        {
            throw new NotFoundException(nameof(Group), request.Id);
        }

        beautifyDbContext.Groups.Remove(group);
        await beautifyDbContext.SaveChangesAsync(cancellationToken);
    }
}
