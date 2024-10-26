using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class GenderPsaRepository : EfRepositoryBase<GenderPsa, Guid, BaseDbContext>, IGenderPsaRepository
{
    public GenderPsaRepository(BaseDbContext context) : base(context)
    {
    }
}