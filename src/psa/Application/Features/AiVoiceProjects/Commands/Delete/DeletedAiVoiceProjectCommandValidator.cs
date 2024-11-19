using FluentValidation;

namespace Application.Features.AiVoiceProjects.Commands.Delete;

public class DeleteAiVoiceProjectCommandValidator : AbstractValidator<DeleteAiVoiceProjectCommand>
{
    public DeleteAiVoiceProjectCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}