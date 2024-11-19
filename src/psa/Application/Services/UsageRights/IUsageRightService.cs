using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.UsageRights;

public interface IUsageRightService
{
    Task<UsageRight?> GetAsync(
        Expression<Func<UsageRight, bool>> predicate,
        Func<IQueryable<UsageRight>, IIncludableQueryable<UsageRight, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<UsageRight>?> GetListAsync(
        Expression<Func<UsageRight, bool>>? predicate = null,
        Func<IQueryable<UsageRight>, IOrderedQueryable<UsageRight>>? orderBy = null,
        Func<IQueryable<UsageRight>, IIncludableQueryable<UsageRight, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<UsageRight> AddAsync(UsageRight usageRight);
    Task<UsageRight> UpdateAsync(UsageRight usageRight);
    Task<UsageRight> DeleteAsync(UsageRight usageRight, bool permanent = false);
}
