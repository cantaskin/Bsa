using FluentValidation;

namespace Application.Features.UsageRights.Commands.Update;

public class UpdateUsageRightCommandValidator : AbstractValidator<UpdateUsageRightCommand>
{
    public UpdateUsageRightCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty().MinimumLength(3).WithMessage("Name must be at least 3 characters long.")
            .MaximumLength(15).WithMessage("Name must not exceed 15 characters."); ;
        RuleFor(c => c.Description).MinimumLength(3).WithMessage("Description must be at least 3 characters long.")
            .MaximumLength(300).WithMessage("Description must not exceed 300 characters.");
    }
}