using NArchitecture.Core.Application.Responses;

namespace Application.Features.BlogCategories.Commands.Delete;

public class DeletedBlogCategoryResponse : IResponse
{
    public Guid Id { get; set; }
}