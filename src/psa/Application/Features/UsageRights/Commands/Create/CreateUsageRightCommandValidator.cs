using FluentValidation;

namespace Application.Features.UsageRights.Commands.Create;

public class CreateUsageRightCommandValidator : AbstractValidator<CreateUsageRightCommand>
{
    public CreateUsageRightCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty().MinimumLength(3).WithMessage("Name must be at least 3 characters long.")
            .MaximumLength(15).WithMessage("Name must not exceed 15 characters."); ;
        RuleFor(c => c.Description).MinimumLength(3).WithMessage("Description must be at least 3 characters long.")
            .MaximumLength(300).WithMessage("Description must not exceed 300 characters.");
    }
}