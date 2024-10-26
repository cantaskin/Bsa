using FluentValidation;

namespace Application.Features.GenderPsas.Commands.Create;

public class CreateGenderPsaCommandValidator : AbstractValidator<CreateGenderPsaCommand>
{
    public CreateGenderPsaCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
    }
}