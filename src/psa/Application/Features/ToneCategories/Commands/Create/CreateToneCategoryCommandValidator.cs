using FluentValidation;

namespace Application.Features.ToneCategories.Commands.Create;

public class CreateToneCategoryCommandValidator : AbstractValidator<CreateToneCategoryCommand>
{
    public CreateToneCategoryCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty().MinimumLength(3).WithMessage("Name must be at least 3 characters long.")
            .MaximumLength(15).WithMessage("Name must not exceed 15 characters."); ;
    }
}