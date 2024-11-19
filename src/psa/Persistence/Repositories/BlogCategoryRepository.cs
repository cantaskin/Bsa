using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class BlogCategoryRepository : EfRepositoryBase<BlogCategory, Guid, BaseDbContext>, IBlogCategoryRepository
{
    public BlogCategoryRepository(BaseDbContext context) : base(context)
    {
    }
}