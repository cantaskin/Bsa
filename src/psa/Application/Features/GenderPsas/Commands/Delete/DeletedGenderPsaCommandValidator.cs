using FluentValidation;

namespace Application.Features.GenderPsas.Commands.Delete;

public class DeleteGenderPsaCommandValidator : AbstractValidator<DeleteGenderPsaCommand>
{
    public DeleteGenderPsaCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}