using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IRealVoiceProjectRepository : IAsyncRepository<RealVoiceProject, Guid>, IRepository<RealVoiceProject, Guid>
{
}