using Application.Features.ToneCategories.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.ToneCategories.Rules;

public class ToneCategoryBusinessRules : BaseBusinessRules
{
    private readonly IToneCategoryRepository _toneCategoryRepository;
    private readonly ILocalizationService _localizationService;

    public ToneCategoryBusinessRules(IToneCategoryRepository toneCategoryRepository, ILocalizationService localizationService)
    {
        _toneCategoryRepository = toneCategoryRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, ToneCategoriesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task ToneCategoryShouldExistWhenSelected(ToneCategory? toneCategory)
    {
        if (toneCategory == null)
            await throwBusinessException(ToneCategoriesBusinessMessages.ToneCategoryNotExists);
    }

    public async Task ToneCategoryIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        ToneCategory? toneCategory = await _toneCategoryRepository.GetAsync(
            predicate: tc => tc.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ToneCategoryShouldExistWhenSelected(toneCategory);
    }
}