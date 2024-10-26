using Application.Features.Demoes.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Demoes;

public class DemoManager : IDemoService
{
    private readonly IDemoRepository _demoRepository;
    private readonly DemoBusinessRules _demoBusinessRules;

    public DemoManager(IDemoRepository demoRepository, DemoBusinessRules demoBusinessRules)
    {
        _demoRepository = demoRepository;
        _demoBusinessRules = demoBusinessRules;
    }

    public async Task<Demo?> GetAsync(
        Expression<Func<Demo, bool>> predicate,
        Func<IQueryable<Demo>, IIncludableQueryable<Demo, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Demo? demo = await _demoRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return demo;
    }

    public async Task<IPaginate<Demo>?> GetListAsync(
        Expression<Func<Demo, bool>>? predicate = null,
        Func<IQueryable<Demo>, IOrderedQueryable<Demo>>? orderBy = null,
        Func<IQueryable<Demo>, IIncludableQueryable<Demo, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Demo> demoList = await _demoRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return demoList;
    }

    public async Task<Demo> AddAsync(Demo demo)
    {
        Demo addedDemo = await _demoRepository.AddAsync(demo);

        return addedDemo;
    }

    public async Task<Demo> UpdateAsync(Demo demo)
    {
        Demo updatedDemo = await _demoRepository.UpdateAsync(demo);

        return updatedDemo;
    }

    public async Task<Demo> DeleteAsync(Demo demo, bool permanent = false)
    {
        Demo deletedDemo = await _demoRepository.DeleteAsync(demo);

        return deletedDemo;
    }
}
