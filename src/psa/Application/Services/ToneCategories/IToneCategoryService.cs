using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ToneCategories;

public interface IToneCategoryService
{
    Task<ToneCategory?> GetAsync(
        Expression<Func<ToneCategory, bool>> predicate,
        Func<IQueryable<ToneCategory>, IIncludableQueryable<ToneCategory, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<ToneCategory>?> GetListAsync(
        Expression<Func<ToneCategory, bool>>? predicate = null,
        Func<IQueryable<ToneCategory>, IOrderedQueryable<ToneCategory>>? orderBy = null,
        Func<IQueryable<ToneCategory>, IIncludableQueryable<ToneCategory, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<ToneCategory> AddAsync(ToneCategory toneCategory);
    Task<ToneCategory> UpdateAsync(ToneCategory toneCategory);
    Task<ToneCategory> DeleteAsync(ToneCategory toneCategory, bool permanent = false);
}
