using Application.Features.Languages.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using Nest;
using Org.BouncyCastle.Asn1.Ocsp;
using System.Threading;
using Language = Domain.Entities.Language;
using Application.Features.Artists.Constants;

namespace Application.Services.Languages;

public class LanguageManager : ILanguageService
{
    private readonly ILanguageRepository _languageRepository;
    private readonly LanguageBusinessRules _languageBusinessRules;

    public LanguageManager(ILanguageRepository languageRepository, LanguageBusinessRules languageBusinessRules)
    {
        _languageRepository = languageRepository;
        _languageBusinessRules = languageBusinessRules;
    }

    public async Task<Language?> GetAsync(
        Expression<Func<Language, bool>> predicate,
        Func<IQueryable<Language>, IIncludableQueryable<Language, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Language? language = await _languageRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return language;
    }

    public async Task<IPaginate<Language>?> GetListAsync(
        Expression<Func<Language, bool>>? predicate = null,
        Func<IQueryable<Language>, IOrderedQueryable<Language>>? orderBy = null,
        Func<IQueryable<Language>, IIncludableQueryable<Language, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Language> languageList = await _languageRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return languageList;
    }

    public async Task<Language> AddAsync(Language language)
    {
        Language addedLanguage = await _languageRepository.AddAsync(language);

        return addedLanguage;
    }

    public async Task<Language> UpdateAsync(Language language)
    {
        Language updatedLanguage = await _languageRepository.UpdateAsync(language);

        return updatedLanguage;
    }

    public async Task<Language> DeleteAsync(Language language, bool permanent = false)
    {
        Language deletedLanguage = await _languageRepository.DeleteAsync(language);

        return deletedLanguage;
    }

    public async Task<ICollection<Language>> AddLanguageFromIds(ICollection<Guid> languageIds,
        ICollection<Language> languages,
        CancellationToken cancellationToken)
    {
        foreach (var languageId in languageIds)
        {
            await _languageBusinessRules.LanguageIdShouldExistWhenSelected(languageId, cancellationToken);
            var language = await GetAsync(l => l.Id == languageId, cancellationToken: cancellationToken);
            if (language != null)
                languages.Add(language);
        }

        return languages;
    }

    public async Task LanguageShouldExistWhenSelected(Language? language)
    {
        if (language == null)
            await _languageBusinessRules.LanguageShouldExistWhenSelected(language);
    }
}
