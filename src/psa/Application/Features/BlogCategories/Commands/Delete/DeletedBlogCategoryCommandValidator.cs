using FluentValidation;

namespace Application.Features.BlogCategories.Commands.Delete;

public class DeleteBlogCategoryCommandValidator : AbstractValidator<DeleteBlogCategoryCommand>
{
    public DeleteBlogCategoryCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}