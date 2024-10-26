using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IDemoRepository : IAsyncRepository<Demo, Guid>, IRepository<Demo, Guid>
{
}