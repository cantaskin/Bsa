using NArchitecture.Core.Application.Responses;

namespace Application.Features.RealVoiceProjects.Commands.Create;

public class CreatedRealVoiceProjectResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Text { get; set; }
    public string? Url { get; set; }
    public Guid ArtistId { get; set; }
    public Guid LanguageId { get; set; }
    public Guid UsageRightId { get; set; }
    public Guid? DemoId { get; set; }
    public string? Description { get; set; }
}