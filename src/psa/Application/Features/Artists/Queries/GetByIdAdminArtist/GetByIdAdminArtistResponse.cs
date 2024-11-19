using NArchitecture.Core.Application.Responses;

namespace Application.Features.Artists.Queries.GetByIdAdminArtist;

public class GetByIdAdminArtistResponse : IResponse
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string? PhotoUrl { get; set; }
    public string MailAddress { get; set; }
    public ICollection<string>? YoutubeVideosUrl { get; set; }
    public string? InstVoiceId { get; set; }
    public string? ProfVoiceId { get; set; }
    public float InstAiUnitPrice { get; set; }
    public float ProfAiUnitPrice { get; set; }
    public float RealVoiceStampPrice { get; set; }
    public string ToneCategoryName { get; set; }
    public string GenderName { get; set; }
    public ICollection<Guid>? DemoIds { get; set; }
    public ICollection<string> LanguageNames { get; set; }
}