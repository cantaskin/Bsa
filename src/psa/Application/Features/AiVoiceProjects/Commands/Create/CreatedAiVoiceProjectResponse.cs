using NArchitecture.Core.Application.Responses;
using Domain.Enums;

namespace Application.Features.AiVoiceProjects.Commands.Create;

public class CreatedAiVoiceProjectResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Text { get; set; }
    public string? Url { get; set; }
    public Guid ArtistId { get; set; }
    public Guid LanguageId { get; set; }
    public Guid UsageRightId { get; set; }
    public ProjectSelectionEnum ProjectSelection { get; set; }
}