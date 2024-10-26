using Application.Features.GenderPsas.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.GenderPsas;

public class GenderPsaManager : IGenderPsaService
{
    private readonly IGenderPsaRepository _genderPsaRepository;
    private readonly GenderPsaBusinessRules _genderPsaBusinessRules;

    public GenderPsaManager(IGenderPsaRepository genderPsaRepository, GenderPsaBusinessRules genderPsaBusinessRules)
    {
        _genderPsaRepository = genderPsaRepository;
        _genderPsaBusinessRules = genderPsaBusinessRules;
    }

    public async Task<GenderPsa?> GetAsync(
        Expression<Func<GenderPsa, bool>> predicate,
        Func<IQueryable<GenderPsa>, IIncludableQueryable<GenderPsa, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        GenderPsa? genderPsa = await _genderPsaRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return genderPsa;
    }

    public async Task<IPaginate<GenderPsa>?> GetListAsync(
        Expression<Func<GenderPsa, bool>>? predicate = null,
        Func<IQueryable<GenderPsa>, IOrderedQueryable<GenderPsa>>? orderBy = null,
        Func<IQueryable<GenderPsa>, IIncludableQueryable<GenderPsa, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<GenderPsa> genderPsaList = await _genderPsaRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return genderPsaList;
    }

    public async Task<GenderPsa> AddAsync(GenderPsa genderPsa)
    {
        GenderPsa addedGenderPsa = await _genderPsaRepository.AddAsync(genderPsa);

        return addedGenderPsa;
    }

    public async Task<GenderPsa> UpdateAsync(GenderPsa genderPsa)
    {
        GenderPsa updatedGenderPsa = await _genderPsaRepository.UpdateAsync(genderPsa);

        return updatedGenderPsa;
    }

    public async Task<GenderPsa> DeleteAsync(GenderPsa genderPsa, bool permanent = false)
    {
        GenderPsa deletedGenderPsa = await _genderPsaRepository.DeleteAsync(genderPsa);

        return deletedGenderPsa;
    }
}
