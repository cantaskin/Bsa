using FluentValidation;

namespace Application.Features.RealVoiceProjects.Commands.Accept;

public class AcceptRealVoiceProjectCommandValidator : AbstractValidator<AcceptRealVoiceProjectCommand>
{
    public AcceptRealVoiceProjectCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}