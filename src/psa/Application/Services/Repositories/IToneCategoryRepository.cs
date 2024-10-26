using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IToneCategoryRepository : IAsyncRepository<ToneCategory, Guid>, IRepository<ToneCategory, Guid>
{
}