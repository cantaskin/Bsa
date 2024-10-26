using FluentValidation;

namespace Application.Features.Artists.Commands.Update;

public class UpdateArtistCommandValidator : AbstractValidator<UpdateArtistCommand>
{
    public UpdateArtistCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.UserName).NotEmpty();
        RuleFor(c => c.MailAddress).NotEmpty();
        RuleFor(c => c.InstAiUnitPrice).NotEmpty();
        RuleFor(c => c.ProfAiUnitPrice).NotEmpty();
        RuleFor(c => c.RealVoiceStampPrice).NotEmpty();
        RuleFor(c => c.ToneCategoryId).NotEmpty();
        RuleFor(c => c.GenderPsaId).NotEmpty();
    }
}