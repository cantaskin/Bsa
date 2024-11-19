using NArchitecture.Core.Application.Dtos;

namespace Application.Features.BlogCategories.Queries.GetList;

public class GetListBlogCategoryListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}