using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Artists.Queries.GetDynamicList;

public class GetDynamicListArtistListItemDto : IDto
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string? PhotoUrl { get; set; }
}