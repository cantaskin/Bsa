using FluentValidation;

namespace Application.Features.Blogs.Commands.Update;

public class UpdateBlogCommandValidator : AbstractValidator<UpdateBlogCommand>
{
    public UpdateBlogCommandValidator()
    {
        RuleFor(c => c.Id)
            .NotEmpty().WithMessage("Id is required.");

        RuleFor(c => c.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MinimumLength(5).WithMessage("Title must be at least 5 characters long.")
            .MaximumLength(15).WithMessage("Title must not exceed 15 characters.");

        RuleFor(c => c.Content)
            .NotEmpty().WithMessage("Content is required.")
            .MinimumLength(50).WithMessage("Content must be at least 50 characters long.")
            .MaximumLength(5000).WithMessage("Content must not exceed 5000 characters.");

        RuleFor(c => c.BlogCategoryId)
            .NotEmpty().WithMessage("BlogCategoryId is required.");
    }
}