using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class DemoRepository : EfRepositoryBase<Demo, Guid, BaseDbContext>, IDemoRepository
{
    public DemoRepository(BaseDbContext context) : base(context)
    {
    }
}