﻿using MediatR;

namespace Beautify.Application.Groups.Commands.CreateGroup;

public class CreateGroupCommand : IRequest<int>
{
    public required string Title { get; set; }
    public string? Description { get; set; }
}
