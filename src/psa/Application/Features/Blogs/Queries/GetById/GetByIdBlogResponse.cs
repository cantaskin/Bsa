using NArchitecture.Core.Application.Responses;

namespace Application.Features.Blogs.Queries.GetById;

public class GetByIdBlogResponse : IResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
   // public int ViewCount { get; set; }
    public string? ThumbnailUrl { get; set; }
}