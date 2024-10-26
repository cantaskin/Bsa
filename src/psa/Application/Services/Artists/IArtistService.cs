using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Artists;

public interface IArtistService
{
    Task<Artist?> GetAsync(
        Expression<Func<Artist, bool>> predicate,
        Func<IQueryable<Artist>, IIncludableQueryable<Artist, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Artist>?> GetListAsync(
        Expression<Func<Artist, bool>>? predicate = null,
        Func<IQueryable<Artist>, IOrderedQueryable<Artist>>? orderBy = null,
        Func<IQueryable<Artist>, IIncludableQueryable<Artist, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Artist> AddAsync(Artist artist);
    Task<Artist> UpdateAsync(Artist artist);
    Task<Artist> DeleteAsync(Artist artist, bool permanent = false);

    ICollection<Guid> GetIdsFromCollection<T>(ICollection<T> collection) where T : Entity<Guid>;
}
