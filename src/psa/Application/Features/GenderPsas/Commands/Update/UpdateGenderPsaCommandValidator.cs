using FluentValidation;

namespace Application.Features.GenderPsas.Commands.Update;

public class UpdateGenderPsaCommandValidator : AbstractValidator<UpdateGenderPsaCommand>
{
    public UpdateGenderPsaCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
    }
}