using FluentValidation;

namespace Application.Features.Languages.Commands.Create;

public class CreateLanguageCommandValidator : AbstractValidator<CreateLanguageCommand>
{
    public CreateLanguageCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(l => l.LanguageCode).NotEmpty().WithMessage("LanguageCode is required.")
            .Length(2).WithMessage("LanguageCode must be 2 characters long");
    }
}