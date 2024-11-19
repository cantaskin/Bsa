using FluentValidation;

namespace Application.Features.AiVoiceProjects.Commands.Create;

public class CreateAiVoiceProjectCommandValidator : AbstractValidator<CreateAiVoiceProjectCommand>
{
    public CreateAiVoiceProjectCommandValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MinimumLength(3).WithMessage("Name must be at least 3 characters long.")
            .MaximumLength(12).WithMessage("Name must not exceed 12 characters.");

        RuleFor(c => c.Text)
            .NotEmpty().WithMessage("Text is required.")
            .MinimumLength(15).WithMessage("Text must be at least 15 characters long.")
            .MaximumLength(2000).WithMessage("Text must not exceed 2000 characters.");

        RuleFor(c => c.ArtistId)
            .NotEmpty().WithMessage("ArtistId is required.");

        RuleFor(c => c.LanguageId)
            .NotEmpty().WithMessage("LanguageId is required.");

        RuleFor(c => c.UsageRightId)
            .NotEmpty().WithMessage("UsageRightId is required.");

        RuleFor(c => c.ProjectSelection)
            .NotEmpty().WithMessage("ProjectSelection is required.")
        .IsInEnum().WithMessage("Invalid ProjectSelection value.");
    }
}