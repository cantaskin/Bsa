using FluentValidation;

namespace Application.Features.Artists.Commands.Create;

public class CreateArtistCommandValidator : AbstractValidator<CreateArtistCommand>
{
    public CreateArtistCommandValidator()
    {
        RuleFor(c => c.UserName).NotEmpty().MinimumLength(3).MaximumLength(9);
        RuleFor(c => c.MailAddress).NotEmpty().EmailAddress().WithMessage("Please, write mail address correctly.");
        RuleFor(c => c.InstAiUnitPrice).NotEmpty().GreaterThan(0);
        RuleFor(c => c.ProfAiUnitPrice).NotEmpty().GreaterThan(0);
        RuleFor(c => c.RealVoiceStampPrice).NotEmpty().GreaterThan(0);
        RuleFor(c => c.ToneCategoryId).NotEmpty();
        RuleFor(c => c.Gender).NotEmpty().IsInEnum();
    }
}