using NArchitecture.Core.Application.Dtos;
using Domain.Enums;

namespace Application.Features.AiVoiceProjects.Queries.GetList;

public class GetListAiVoiceProjectListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid ArtistId { get; set; }
    public ProjectSelectionEnum ProjectSelection { get; set; } 
}