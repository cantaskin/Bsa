using NArchitecture.Core.Application.Dtos;

namespace Application.Features.ToneCategories.Queries.GetList;

public class GetListToneCategoryListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}