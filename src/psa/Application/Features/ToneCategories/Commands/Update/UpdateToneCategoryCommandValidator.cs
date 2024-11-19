using FluentValidation;

namespace Application.Features.ToneCategories.Commands.Update;

public class UpdateToneCategoryCommandValidator : AbstractValidator<UpdateToneCategoryCommand>
{
    public UpdateToneCategoryCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty().MinimumLength(3).WithMessage("Name must be at least 3 characters long.")
            .MaximumLength(15).WithMessage("Name must not exceed 15 characters."); ;
    }
}