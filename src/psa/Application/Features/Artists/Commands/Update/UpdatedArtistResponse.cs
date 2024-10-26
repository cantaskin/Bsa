using NArchitecture.Core.Application.Responses;

namespace Application.Features.Artists.Commands.Update;

public class UpdatedArtistResponse : IResponse
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string? PhotoUrl { get; set; }
    public string MailAddress { get; set; }
    public string? YoutubeAddress { get; set; }
    public float InstAiUnitPrice { get; set; }
    public float ProfAiUnitPrice { get; set; }
    public float RealVoiceStampPrice { get; set; }
    public Guid ToneCategoryId { get; set; }
    public Guid GenderId { get; set; }
}