using NArchitecture.Core.Application.Responses;

namespace Application.Features.Artists.Queries.GetByIdArtist;

public class GetByIdArtistResponse : IResponse
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string? PhotoUrl { get; set; }
    public string? YoutubeAddress { get; set; }
    public float InstAiUnitPrice { get; set; }
    public float ProfAiUnitPrice { get; set; }
    public float RealVoiceStampPrice { get; set; }
    public string ToneCategoryName { get; set; }
    public string GenderName { get; set; }
    public ICollection<Guid> DemoIds { get; set; }
    public ICollection<string> LanguageNames { get; set; }
}