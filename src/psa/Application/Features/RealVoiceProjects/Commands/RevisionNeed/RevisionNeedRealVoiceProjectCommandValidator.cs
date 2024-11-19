using FluentValidation;

namespace Application.Features.RealVoiceProjects.Commands.RevisionNeed;

public class RevisionNeedRealVoiceProjectCommandValidator : AbstractValidator<RevisionNeedRealVoiceProjectCommand>
{
    public RevisionNeedRealVoiceProjectCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Text).NotEmpty().MinimumLength(30).WithMessage("Text must be at least 30 characters long.")
            .MaximumLength(2000).WithMessage("Text must not exceed 2000 characters.");
        RuleFor(c => c.ArtistId).NotEmpty();
        RuleFor(c => c.LanguageId).NotEmpty();
        RuleFor(c => c.UsageRightId).NotEmpty();
    }
}