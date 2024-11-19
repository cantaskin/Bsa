using Application.Features.RealVoiceProjects.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.RealVoiceProjects;

public class RealVoiceProjectManager : IRealVoiceProjectService
{
    private readonly IRealVoiceProjectRepository _realVoiceProjectRepository;
    private readonly RealVoiceProjectBusinessRules _realVoiceProjectBusinessRules;

    public RealVoiceProjectManager(IRealVoiceProjectRepository realVoiceProjectRepository, RealVoiceProjectBusinessRules realVoiceProjectBusinessRules)
    {
        _realVoiceProjectRepository = realVoiceProjectRepository;
        _realVoiceProjectBusinessRules = realVoiceProjectBusinessRules;
    }

    public async Task<RealVoiceProject?> GetAsync(
        Expression<Func<RealVoiceProject, bool>> predicate,
        Func<IQueryable<RealVoiceProject>, IIncludableQueryable<RealVoiceProject, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        RealVoiceProject? realVoiceProject = await _realVoiceProjectRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return realVoiceProject;
    }

    public async Task<IPaginate<RealVoiceProject>?> GetListAsync(
        Expression<Func<RealVoiceProject, bool>>? predicate = null,
        Func<IQueryable<RealVoiceProject>, IOrderedQueryable<RealVoiceProject>>? orderBy = null,
        Func<IQueryable<RealVoiceProject>, IIncludableQueryable<RealVoiceProject, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<RealVoiceProject> realVoiceProjectList = await _realVoiceProjectRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return realVoiceProjectList;
    }

    public async Task<RealVoiceProject> AddAsync(RealVoiceProject realVoiceProject)
    {
        RealVoiceProject addedRealVoiceProject = await _realVoiceProjectRepository.AddAsync(realVoiceProject);

        return addedRealVoiceProject;
    }

    public async Task<RealVoiceProject> UpdateAsync(RealVoiceProject realVoiceProject)
    {
        RealVoiceProject updatedRealVoiceProject = await _realVoiceProjectRepository.UpdateAsync(realVoiceProject);

        return updatedRealVoiceProject;
    }

    public async Task<RealVoiceProject> DeleteAsync(RealVoiceProject realVoiceProject, bool permanent = false)
    {
        RealVoiceProject deletedRealVoiceProject = await _realVoiceProjectRepository.DeleteAsync(realVoiceProject);

        return deletedRealVoiceProject;
    }
}
