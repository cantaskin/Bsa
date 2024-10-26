using FluentValidation;

namespace Application.Features.ToneCategories.Commands.Update;

public class UpdateToneCategoryCommandValidator : AbstractValidator<UpdateToneCategoryCommand>
{
    public UpdateToneCategoryCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
    }
}