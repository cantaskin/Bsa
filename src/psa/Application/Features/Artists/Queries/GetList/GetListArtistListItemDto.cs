using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Artists.Queries.GetList;

public class GetListArtistListItemDto : IDto
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string? PhotoUrl { get; set; }
}