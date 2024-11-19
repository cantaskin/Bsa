using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.AiVoiceProjects;

public interface IAiVoiceProjectService
{
    Task<AiVoiceProject?> GetAsync(
        Expression<Func<AiVoiceProject, bool>> predicate,
        Func<IQueryable<AiVoiceProject>, IIncludableQueryable<AiVoiceProject, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<AiVoiceProject>?> GetListAsync(
        Expression<Func<AiVoiceProject, bool>>? predicate = null,
        Func<IQueryable<AiVoiceProject>, IOrderedQueryable<AiVoiceProject>>? orderBy = null,
        Func<IQueryable<AiVoiceProject>, IIncludableQueryable<AiVoiceProject, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<AiVoiceProject> AddAsync(AiVoiceProject aiVoiceProject);
    Task<AiVoiceProject> UpdateAsync(AiVoiceProject aiVoiceProject);
    Task<AiVoiceProject> DeleteAsync(AiVoiceProject aiVoiceProject, bool permanent = false);
}
