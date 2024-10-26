using FluentValidation;

namespace Application.Features.ToneCategories.Commands.Delete;

public class DeleteToneCategoryCommandValidator : AbstractValidator<DeleteToneCategoryCommand>
{
    public DeleteToneCategoryCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}