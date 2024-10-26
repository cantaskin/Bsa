using FluentValidation;

namespace Application.Features.Artists.Commands.Create;

public class CreateArtistCommandValidator : AbstractValidator<CreateArtistCommand>
{
    public CreateArtistCommandValidator()
    {
        RuleFor(c => c.UserName).NotEmpty();
        RuleFor(c => c.MailAddress).NotEmpty();
        RuleFor(c => c.InstAiUnitPrice).NotEmpty();
        RuleFor(c => c.ProfAiUnitPrice).NotEmpty();
        RuleFor(c => c.RealVoiceStampPrice).NotEmpty();
        RuleFor(c => c.ToneCategoryId).NotEmpty();
        RuleFor(c => c.GenderPsaId).NotEmpty();
    }
}