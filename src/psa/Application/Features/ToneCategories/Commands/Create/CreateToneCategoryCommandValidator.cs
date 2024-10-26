using FluentValidation;

namespace Application.Features.ToneCategories.Commands.Create;

public class CreateToneCategoryCommandValidator : AbstractValidator<CreateToneCategoryCommand>
{
    public CreateToneCategoryCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
    }
}