using FluentValidation;

namespace Application.Features.RealVoiceProjects.Commands.Reject;

public class RejectRealVoiceProjectCommandValidator : AbstractValidator<RejectRealVoiceProjectCommand>
{
    public RejectRealVoiceProjectCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}