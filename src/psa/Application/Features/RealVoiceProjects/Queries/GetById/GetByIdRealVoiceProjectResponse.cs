using NArchitecture.Core.Application.Responses;

namespace Application.Features.RealVoiceProjects.Queries.GetById;

public class GetByIdRealVoiceProjectResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Text { get; set; }
    public Guid ArtistId { get; set; }
    public Guid LanguageId { get; set; }
    public Guid UsageRightId { get; set; }
    public Guid? DemoId { get; set; }
    public ICollection<string>? FileUrls { get; set; } //burada urlleri vereceðim.
    public string? Description { get; set; }
}