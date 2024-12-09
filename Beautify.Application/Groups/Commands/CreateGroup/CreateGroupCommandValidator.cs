using FluentValidation;

namespace Beautify.Application.Groups.Commands.CreateGroup;
public class CreateGroupCommandValidator : AbstractValidator<CreateGroupCommand>
{
    public CreateGroupCommandValidator()
    {
        RuleFor(createNoteCommand =>
                    createNoteCommand.Title)
            .NotEmpty()
            .MaximumLength(50);
    }
}