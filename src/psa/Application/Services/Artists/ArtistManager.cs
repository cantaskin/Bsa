using Application.Features.Artists.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Artists;

public class ArtistManager : IArtistService
{
    private readonly IArtistRepository _artistRepository;
    private readonly ArtistBusinessRules _artistBusinessRules;

    public ArtistManager(IArtistRepository artistRepository, ArtistBusinessRules artistBusinessRules)
    {
        _artistRepository = artistRepository;
        _artistBusinessRules = artistBusinessRules;
    }

    public async Task<Artist?> GetAsync(
        Expression<Func<Artist, bool>> predicate,
        Func<IQueryable<Artist>, IIncludableQueryable<Artist, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Artist? artist = await _artistRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return artist;
    }

    public async Task<IPaginate<Artist>?> GetListAsync(
        Expression<Func<Artist, bool>>? predicate = null,
        Func<IQueryable<Artist>, IOrderedQueryable<Artist>>? orderBy = null,
        Func<IQueryable<Artist>, IIncludableQueryable<Artist, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Artist> artistList = await _artistRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return artistList;
    }

    public async Task<Artist> AddAsync(Artist artist)
    {
        Artist addedArtist = await _artistRepository.AddAsync(artist);

        return addedArtist;
    }

    public async Task<Artist> UpdateAsync(Artist artist)
    {
        Artist updatedArtist = await _artistRepository.UpdateAsync(artist);

        return updatedArtist;
    }

    public async Task<Artist> DeleteAsync(Artist artist, bool permanent = false)
    {
        Artist deletedArtist = await _artistRepository.DeleteAsync(artist);

        return deletedArtist;
    }

    public ICollection<Guid> GetIdsFromCollection<T>(ICollection<T> collection) where T : Entity<Guid>
    {
        ICollection<Guid> ids = new HashSet<Guid>();
        foreach (var item in collection)
        {
            ids.Add(item.Id);
        }
        return ids;
    }
}
