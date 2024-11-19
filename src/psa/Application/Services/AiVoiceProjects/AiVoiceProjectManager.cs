using Application.Features.AiVoiceProjects.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.AiVoiceProjects;

public class AiVoiceProjectManager : IAiVoiceProjectService
{
    private readonly IAiVoiceProjectRepository _aiVoiceProjectRepository;
    private readonly AiVoiceProjectBusinessRules _aiVoiceProjectBusinessRules;

    public AiVoiceProjectManager(IAiVoiceProjectRepository aiVoiceProjectRepository, AiVoiceProjectBusinessRules aiVoiceProjectBusinessRules)
    {
        _aiVoiceProjectRepository = aiVoiceProjectRepository;
        _aiVoiceProjectBusinessRules = aiVoiceProjectBusinessRules;
    }

    public async Task<AiVoiceProject?> GetAsync(
        Expression<Func<AiVoiceProject, bool>> predicate,
        Func<IQueryable<AiVoiceProject>, IIncludableQueryable<AiVoiceProject, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        AiVoiceProject? aiVoiceProject = await _aiVoiceProjectRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return aiVoiceProject;
    }

    public async Task<IPaginate<AiVoiceProject>?> GetListAsync(
        Expression<Func<AiVoiceProject, bool>>? predicate = null,
        Func<IQueryable<AiVoiceProject>, IOrderedQueryable<AiVoiceProject>>? orderBy = null,
        Func<IQueryable<AiVoiceProject>, IIncludableQueryable<AiVoiceProject, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<AiVoiceProject> aiVoiceProjectList = await _aiVoiceProjectRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return aiVoiceProjectList;
    }

    public async Task<AiVoiceProject> AddAsync(AiVoiceProject aiVoiceProject)
    {
        AiVoiceProject addedAiVoiceProject = await _aiVoiceProjectRepository.AddAsync(aiVoiceProject);

        return addedAiVoiceProject;
    }

    public async Task<AiVoiceProject> UpdateAsync(AiVoiceProject aiVoiceProject)
    {
        AiVoiceProject updatedAiVoiceProject = await _aiVoiceProjectRepository.UpdateAsync(aiVoiceProject);

        return updatedAiVoiceProject;
    }

    public async Task<AiVoiceProject> DeleteAsync(AiVoiceProject aiVoiceProject, bool permanent = false)
    {
        AiVoiceProject deletedAiVoiceProject = await _aiVoiceProjectRepository.DeleteAsync(aiVoiceProject);

        return deletedAiVoiceProject;
    }
}
