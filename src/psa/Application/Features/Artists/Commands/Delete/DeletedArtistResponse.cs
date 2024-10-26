using NArchitecture.Core.Application.Responses;

namespace Application.Features.Artists.Commands.Delete;

public class DeletedArtistResponse : IResponse
{
    public Guid Id { get; set; }
}