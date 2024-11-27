using MediatR;

namespace Beautify.Application.Groups.Queries.GetGroupDetails;

public class GetGroupDetailsQuery : IRequest<GroupDetailsViewModel>
{
    public int Id { get; set; }

}
