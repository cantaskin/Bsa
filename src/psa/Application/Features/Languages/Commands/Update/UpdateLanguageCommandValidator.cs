using FluentValidation;

namespace Application.Features.Languages.Commands.Update;

public class UpdateLanguageCommandValidator : AbstractValidator<UpdateLanguageCommand>
{
    public UpdateLanguageCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty().WithMessage("Name is required.")
            .MinimumLength(3).WithMessage("Name must be at least 3 characters long.")
            .MaximumLength(15).WithMessage("Name must not exceed 15 characters.");
        RuleFor(l => l.LanguageCode).NotEmpty().WithMessage("LanguageCode is required.")
            .Length(2).WithMessage("LanguageCode must be 2 characters long");
    }
}