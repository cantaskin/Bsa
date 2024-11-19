using FluentValidation;

namespace Application.Features.BlogCategories.Commands.Update;

public class UpdateBlogCategoryCommandValidator : AbstractValidator<UpdateBlogCategoryCommand>
{
    public UpdateBlogCategoryCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty().WithMessage("Name is required.")
            .MinimumLength(3).WithMessage("Name must be at least 3 characters long.")
            .MaximumLength(15).WithMessage("Name must not exceed 15 characters."); ;
    }
}