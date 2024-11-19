using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IBlogRepository : IAsyncRepository<Blog, Guid>, IRepository<Blog, Guid>
{
}