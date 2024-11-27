using Beautify.Application.Interfaces;
using Beautify.Domain;
using MediatR;

namespace Beautify.Application.Groups.Commands.CreateGroup;

public class CreateGroupCommandHandler(IBeautifyDbContext beautifyDbContext) : IRequestHandler<CreateGroupCommand, int>
{
    public async Task<int> Handle(CreateGroupCommand request, CancellationToken cancellationToken)
    {
        var group = new Group
        {
            Title = request.Title,
            Description = request.Description,
            
        };
        await beautifyDbContext.Groups.AddAsync(group,cancellationToken);
        await beautifyDbContext.SaveChangesAsync(cancellationToken);

        return group.Id;
    }
}
