using FluentValidation;

namespace Application.Features.RealVoiceProjects.Commands.Delete;

public class DeleteRealVoiceProjectCommandValidator : AbstractValidator<DeleteRealVoiceProjectCommand>
{
    public DeleteRealVoiceProjectCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}