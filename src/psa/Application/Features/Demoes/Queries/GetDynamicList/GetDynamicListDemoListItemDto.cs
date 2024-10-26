using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Demoes.Queries.GetDynamicList;

public class GetDynamicListDemoListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Url { get; set; }
    public Guid LanguageId { get; set; }
    public Guid CategoryId { get; set; }
}