using NArchitecture.Core.Application.Responses;

namespace Application.Features.Blogs.Commands.Update;

public class UpdatedBlogResponse : IResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public int ViewCount { get; set; }
    public string? ThumbnailUrl { get; set; }

    public required Guid BlogCategoryId { get; set; }
}