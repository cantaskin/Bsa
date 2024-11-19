using NArchitecture.Core.Application.Dtos;

namespace Application.Features.RealVoiceProjects.Queries.GetList;

public class GetListRealVoiceProjectListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid ArtistId { get; set; }
}