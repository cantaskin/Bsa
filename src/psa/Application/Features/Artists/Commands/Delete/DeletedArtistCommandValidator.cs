using FluentValidation;

namespace Application.Features.Artists.Commands.Delete;

public class DeleteArtistCommandValidator : AbstractValidator<DeleteArtistCommand>
{
    public DeleteArtistCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}