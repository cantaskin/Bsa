using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Demoes;

public interface IDemoService
{
    Task<Demo?> GetAsync(
        Expression<Func<Demo, bool>> predicate,
        Func<IQueryable<Demo>, IIncludableQueryable<Demo, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Demo>?> GetListAsync(
        Expression<Func<Demo, bool>>? predicate = null,
        Func<IQueryable<Demo>, IOrderedQueryable<Demo>>? orderBy = null,
        Func<IQueryable<Demo>, IIncludableQueryable<Demo, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Demo> AddAsync(Demo demo);
    Task<Demo> UpdateAsync(Demo demo);
    Task<Demo> DeleteAsync(Demo demo, bool permanent = false);
}
