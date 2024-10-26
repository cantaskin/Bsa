using FluentValidation;

namespace Application.Features.Demoes.Commands.Update;

public class UpdateDemoCommandValidator : AbstractValidator<UpdateDemoCommand>
{
    public UpdateDemoCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Url).NotEmpty();
        RuleFor(c => c.LanguageId).NotEmpty();
        RuleFor(c => c.ArtistId).NotEmpty();
        RuleFor(c => c.CategoryId).NotEmpty();
    }
}