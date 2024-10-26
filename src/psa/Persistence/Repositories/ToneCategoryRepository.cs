using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ToneCategoryRepository : EfRepositoryBase<ToneCategory, Guid, BaseDbContext>, IToneCategoryRepository
{
    public ToneCategoryRepository(BaseDbContext context) : base(context)
    {
    }
}