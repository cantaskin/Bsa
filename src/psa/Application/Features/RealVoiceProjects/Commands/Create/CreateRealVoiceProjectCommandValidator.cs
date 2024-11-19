using FluentValidation;

namespace Application.Features.RealVoiceProjects.Commands.Create;

public class CreateRealVoiceProjectCommandValidator : AbstractValidator<CreateRealVoiceProjectCommand>
{
    public CreateRealVoiceProjectCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty().MinimumLength(3).WithMessage("Name must be at least 3 characters long.")
            .MaximumLength(50).WithMessage("Name must not exceed 50 characters."); ;
        RuleFor(c => c.Text).MinimumLength(30).WithMessage("Text must be at least 30 characters long.")
            .MaximumLength(2000).WithMessage("Text must not exceed 2000 characters.");
        RuleFor(c => c.ArtistId).NotEmpty();
        RuleFor(c => c.LanguageId).NotEmpty();
        RuleFor(c => c.UsageRightId).NotEmpty();
    }
}