using NArchitecture.Core.Application.Responses;

namespace Application.Features.BlogCategories.Queries.GetById;

public class GetByIdBlogCategoryResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}