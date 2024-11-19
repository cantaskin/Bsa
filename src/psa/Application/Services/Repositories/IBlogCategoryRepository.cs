using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IBlogCategoryRepository : IAsyncRepository<BlogCategory, Guid>, IRepository<BlogCategory, Guid>
{
}