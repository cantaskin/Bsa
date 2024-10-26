using FluentValidation;

namespace Application.Features.Demoes.Commands.Create;

public class CreateDemoCommandValidator : AbstractValidator<CreateDemoCommand>
{
    public CreateDemoCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Url).NotEmpty();
        RuleFor(c => c.LanguageId).NotEmpty();
        RuleFor(c => c.ArtistId).NotEmpty();
        RuleFor(c => c.CategoryId).NotEmpty();
    }
}