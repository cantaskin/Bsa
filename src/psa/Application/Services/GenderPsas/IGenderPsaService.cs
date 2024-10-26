using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.GenderPsas;

public interface IGenderPsaService
{
    Task<GenderPsa?> GetAsync(
        Expression<Func<GenderPsa, bool>> predicate,
        Func<IQueryable<GenderPsa>, IIncludableQueryable<GenderPsa, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<GenderPsa>?> GetListAsync(
        Expression<Func<GenderPsa, bool>>? predicate = null,
        Func<IQueryable<GenderPsa>, IOrderedQueryable<GenderPsa>>? orderBy = null,
        Func<IQueryable<GenderPsa>, IIncludableQueryable<GenderPsa, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<GenderPsa> AddAsync(GenderPsa genderPsa);
    Task<GenderPsa> UpdateAsync(GenderPsa genderPsa);
    Task<GenderPsa> DeleteAsync(GenderPsa genderPsa, bool permanent = false);
}
