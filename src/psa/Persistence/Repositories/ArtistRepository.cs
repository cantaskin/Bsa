using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ArtistRepository : EfRepositoryBase<Artist, Guid, BaseDbContext>, IArtistRepository
{
    public ArtistRepository(BaseDbContext context) : base(context)
    {
    }
}