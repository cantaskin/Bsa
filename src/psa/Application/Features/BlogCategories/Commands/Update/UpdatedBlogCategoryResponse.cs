using NArchitecture.Core.Application.Responses;

namespace Application.Features.BlogCategories.Commands.Update;

public class UpdatedBlogCategoryResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}