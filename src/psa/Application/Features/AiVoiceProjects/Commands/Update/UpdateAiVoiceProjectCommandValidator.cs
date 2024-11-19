using FluentValidation;

namespace Application.Features.AiVoiceProjects.Commands.Update;

public class UpdateAiVoiceProjectCommandValidator : AbstractValidator<UpdateAiVoiceProjectCommand>
{
    public UpdateAiVoiceProjectCommandValidator()
    {
        RuleFor(c => c.Id)
            .NotEmpty()
            .WithMessage("Id is required.");

        RuleFor(c => c.Name)
            .NotEmpty()
            .MinimumLength(3).WithMessage("Name must be at least 3 characters long.")
            .MaximumLength(12).WithMessage("Name must not exceed 12 characters.");

        RuleFor(c => c.Text)
            .NotEmpty()
            .MinimumLength(30).WithMessage("Text must be at least 30 characters long.")
            .MaximumLength(2000).WithMessage("Text must not exceed 2000 characters.");

        RuleFor(c => c.ArtistId)
            .NotEmpty()
            .WithMessage("ArtistId is required.");

        RuleFor(c => c.LanguageId)
            .NotEmpty()
            .WithMessage("LanguageId is required.");

        RuleFor(c => c.UsageRightId)
            .NotEmpty()
            .WithMessage("UsageRightId is required.");

        RuleFor(c => c.ProjectSelection)
            .NotEmpty()
            .IsInEnum()
            .WithMessage("Invalid ProjectSelection value.");
    }
}