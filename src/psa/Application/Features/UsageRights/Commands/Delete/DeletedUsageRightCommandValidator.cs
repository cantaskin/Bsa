using FluentValidation;

namespace Application.Features.UsageRights.Commands.Delete;

public class DeleteUsageRightCommandValidator : AbstractValidator<DeleteUsageRightCommand>
{
    public DeleteUsageRightCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}