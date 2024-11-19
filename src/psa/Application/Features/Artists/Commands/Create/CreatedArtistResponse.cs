using Domain.Entities;
using Domain.Enums;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.Artists.Commands.Create;

public class CreatedArtistResponse : IResponse
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string? PhotoUrl { get; set; }
    public string MailAddress { get; set; }
    public IList<string>? YoutubeVideosUrl { get; set; }
    public string? InstVoiceId { get; set; }
    public string? ProfVoiceId { get; set; }
    public float InstAiUnitPrice { get; set; }
    public float ProfAiUnitPrice { get; set; }
    public float RealVoiceStampPrice { get; set; }
    public Guid ToneCategoryId { get; set; }
    public GenderEnum Gender { get; set; }

    public ICollection<Guid> LanguageIds { get; set; }
}