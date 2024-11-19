using Application.Features.UsageRights.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.UsageRights;

public class UsageRightManager : IUsageRightService
{
    private readonly IUsageRightRepository _usageRightRepository;
    private readonly UsageRightBusinessRules _usageRightBusinessRules;

    public UsageRightManager(IUsageRightRepository usageRightRepository, UsageRightBusinessRules usageRightBusinessRules)
    {
        _usageRightRepository = usageRightRepository;
        _usageRightBusinessRules = usageRightBusinessRules;
    }

    public async Task<UsageRight?> GetAsync(
        Expression<Func<UsageRight, bool>> predicate,
        Func<IQueryable<UsageRight>, IIncludableQueryable<UsageRight, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        UsageRight? usageRight = await _usageRightRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return usageRight;
    }

    public async Task<IPaginate<UsageRight>?> GetListAsync(
        Expression<Func<UsageRight, bool>>? predicate = null,
        Func<IQueryable<UsageRight>, IOrderedQueryable<UsageRight>>? orderBy = null,
        Func<IQueryable<UsageRight>, IIncludableQueryable<UsageRight, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<UsageRight> usageRightList = await _usageRightRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return usageRightList;
    }

    public async Task<UsageRight> AddAsync(UsageRight usageRight)
    {
        UsageRight addedUsageRight = await _usageRightRepository.AddAsync(usageRight);

        return addedUsageRight;
    }

    public async Task<UsageRight> UpdateAsync(UsageRight usageRight)
    {
        UsageRight updatedUsageRight = await _usageRightRepository.UpdateAsync(usageRight);

        return updatedUsageRight;
    }

    public async Task<UsageRight> DeleteAsync(UsageRight usageRight, bool permanent = false)
    {
        UsageRight deletedUsageRight = await _usageRightRepository.DeleteAsync(usageRight);

        return deletedUsageRight;
    }
}
