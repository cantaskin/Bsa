using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IGenderPsaRepository : IAsyncRepository<GenderPsa, Guid>, IRepository<GenderPsa, Guid>
{
}