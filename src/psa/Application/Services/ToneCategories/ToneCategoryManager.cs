using Application.Features.ToneCategories.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ToneCategories;

public class ToneCategoryManager : IToneCategoryService
{
    private readonly IToneCategoryRepository _toneCategoryRepository;
    private readonly ToneCategoryBusinessRules _toneCategoryBusinessRules;

    public ToneCategoryManager(IToneCategoryRepository toneCategoryRepository, ToneCategoryBusinessRules toneCategoryBusinessRules)
    {
        _toneCategoryRepository = toneCategoryRepository;
        _toneCategoryBusinessRules = toneCategoryBusinessRules;
    }

    public async Task<ToneCategory?> GetAsync(
        Expression<Func<ToneCategory, bool>> predicate,
        Func<IQueryable<ToneCategory>, IIncludableQueryable<ToneCategory, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        ToneCategory? toneCategory = await _toneCategoryRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return toneCategory;
    }

    public async Task<IPaginate<ToneCategory>?> GetListAsync(
        Expression<Func<ToneCategory, bool>>? predicate = null,
        Func<IQueryable<ToneCategory>, IOrderedQueryable<ToneCategory>>? orderBy = null,
        Func<IQueryable<ToneCategory>, IIncludableQueryable<ToneCategory, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<ToneCategory> toneCategoryList = await _toneCategoryRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return toneCategoryList;
    }

    public async Task<ToneCategory> AddAsync(ToneCategory toneCategory)
    {
        ToneCategory addedToneCategory = await _toneCategoryRepository.AddAsync(toneCategory);

        return addedToneCategory;
    }

    public async Task<ToneCategory> UpdateAsync(ToneCategory toneCategory)
    {
        ToneCategory updatedToneCategory = await _toneCategoryRepository.UpdateAsync(toneCategory);

        return updatedToneCategory;
    }

    public async Task<ToneCategory> DeleteAsync(ToneCategory toneCategory, bool permanent = false)
    {
        ToneCategory deletedToneCategory = await _toneCategoryRepository.DeleteAsync(toneCategory);

        return deletedToneCategory;
    }
}
