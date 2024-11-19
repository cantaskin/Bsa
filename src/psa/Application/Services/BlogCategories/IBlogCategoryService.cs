using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.BlogCategories;

public interface IBlogCategoryService
{
    Task<BlogCategory?> GetAsync(
        Expression<Func<BlogCategory, bool>> predicate,
        Func<IQueryable<BlogCategory>, IIncludableQueryable<BlogCategory, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<BlogCategory>?> GetListAsync(
        Expression<Func<BlogCategory, bool>>? predicate = null,
        Func<IQueryable<BlogCategory>, IOrderedQueryable<BlogCategory>>? orderBy = null,
        Func<IQueryable<BlogCategory>, IIncludableQueryable<BlogCategory, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<BlogCategory> AddAsync(BlogCategory blogCategory);
    Task<BlogCategory> UpdateAsync(BlogCategory blogCategory);
    Task<BlogCategory> DeleteAsync(BlogCategory blogCategory, bool permanent = false);
}
