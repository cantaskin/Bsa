using Application.Features.GenderPsas.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.GenderPsas.Rules;

public class GenderPsaBusinessRules : BaseBusinessRules
{
    private readonly IGenderPsaRepository _genderPsaRepository;
    private readonly ILocalizationService _localizationService;

    public GenderPsaBusinessRules(IGenderPsaRepository genderPsaRepository, ILocalizationService localizationService)
    {
        _genderPsaRepository = genderPsaRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, GenderPsasBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task GenderPsaShouldExistWhenSelected(GenderPsa? genderPsa)
    {
        if (genderPsa == null)
            await throwBusinessException(GenderPsasBusinessMessages.GenderPsaNotExists);
    }

    public async Task GenderPsaIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        GenderPsa? genderPsa = await _genderPsaRepository.GetAsync(
            predicate: gp => gp.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await GenderPsaShouldExistWhenSelected(genderPsa);
    }
}