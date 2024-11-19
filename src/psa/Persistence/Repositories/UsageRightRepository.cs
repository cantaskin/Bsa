using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class UsageRightRepository : EfRepositoryBase<UsageRight, Guid, BaseDbContext>, IUsageRightRepository
{
    public UsageRightRepository(BaseDbContext context) : base(context)
    {
    }
}