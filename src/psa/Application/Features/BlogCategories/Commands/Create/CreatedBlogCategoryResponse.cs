using NArchitecture.Core.Application.Responses;

namespace Application.Features.BlogCategories.Commands.Create;

public class CreatedBlogCategoryResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}