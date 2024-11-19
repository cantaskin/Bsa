using NArchitecture.Core.Application.Responses;

namespace Application.Features.Blogs.Commands.Create;

public class CreatedBlogResponse : IResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public int ViewCount { get; set; }
    public string? ThumbnailUrl { get; set; }
    public Guid BlogCategoryId { get; set; }
}