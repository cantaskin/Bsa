using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Blog : Entity<Guid>
{
    public string Title { get; set; }
    public string Content { get; set; }
    public int ViewCount { get; set; } = 0;
    public string? ThumbnailUrl { get; set; } //3

    public Guid BlogCategoryId { get; set; }
    public BlogCategory? BlogCategory { get; set; }
}
