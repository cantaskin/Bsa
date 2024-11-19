using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class AiVoiceProjectRepository : EfRepositoryBase<AiVoiceProject, Guid, BaseDbContext>, IAiVoiceProjectRepository
{
    public AiVoiceProjectRepository(BaseDbContext context) : base(context)
    {
    }
}