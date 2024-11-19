using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Blogs.Queries.GetList;

public class GetListBlogListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
  //  public int ViewCount { get; set; }
    public string? ThumbnailUrl { get; set; }
}