using FluentValidation;

namespace Application.Features.Blogs.Commands.Create;

public class CreateBlogCommandValidator : AbstractValidator<CreateBlogCommand>
{
    public CreateBlogCommandValidator()
    {
        RuleFor(c => c.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MinimumLength(5).WithMessage("Title must be at least 5 characters long.")
            .MaximumLength(30).WithMessage("Title must not exceed 30 characters.");

        RuleFor(c => c.Content)
            .NotEmpty().WithMessage("Content is required.")
            .MinimumLength(50).WithMessage("Content must be at least 50 characters long.")
            .MaximumLength(5000).WithMessage("Content must not exceed 5000 characters.");

        RuleFor(c => c.BlogCategoryId)
            .NotEmpty().WithMessage("BlogCategoryId is required.");
    }
}