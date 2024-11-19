using Application.Features.RealVoiceProjects.Commands.Update;
using FluentValidation;

namespace Application.Features.RealVoiceProjects.Commands.Finalize;

public class FinalizeRealVoiceProjectCommandValidator : AbstractValidator<FinalizeRealVoiceProjectCommand>
{
    public FinalizeRealVoiceProjectCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.File).NotEmpty();
    }
}