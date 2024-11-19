using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class RealVoiceProjectRepository : EfRepositoryBase<RealVoiceProject, Guid, BaseDbContext>, IRealVoiceProjectRepository
{
    public RealVoiceProjectRepository(BaseDbContext context) : base(context)
    {
    }
}