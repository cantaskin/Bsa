using FluentValidation;

namespace Application.Features.Demoes.Commands.Delete;

public class DeleteDemoCommandValidator : AbstractValidator<DeleteDemoCommand>
{
    public DeleteDemoCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}