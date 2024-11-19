using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.RealVoiceProjects;

public interface IRealVoiceProjectService
{
    Task<RealVoiceProject?> GetAsync(
        Expression<Func<RealVoiceProject, bool>> predicate,
        Func<IQueryable<RealVoiceProject>, IIncludableQueryable<RealVoiceProject, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<RealVoiceProject>?> GetListAsync(
        Expression<Func<RealVoiceProject, bool>>? predicate = null,
        Func<IQueryable<RealVoiceProject>, IOrderedQueryable<RealVoiceProject>>? orderBy = null,
        Func<IQueryable<RealVoiceProject>, IIncludableQueryable<RealVoiceProject, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<RealVoiceProject> AddAsync(RealVoiceProject realVoiceProject);
    Task<RealVoiceProject> UpdateAsync(RealVoiceProject realVoiceProject);
    Task<RealVoiceProject> DeleteAsync(RealVoiceProject realVoiceProject, bool permanent = false);


}
