using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IArtistRepository : IAsyncRepository<Artist, Guid>, IRepository<Artist, Guid>
{
}