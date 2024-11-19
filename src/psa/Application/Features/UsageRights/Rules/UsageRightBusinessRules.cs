using Application.Features.UsageRights.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.UsageRights.Rules;

public class UsageRightBusinessRules : BaseBusinessRules
{
    private readonly IUsageRightRepository _usageRightRepository;
    private readonly ILocalizationService _localizationService;

    public UsageRightBusinessRules(IUsageRightRepository usageRightRepository, ILocalizationService localizationService)
    {
        _usageRightRepository = usageRightRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, UsageRightsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task UsageRightShouldExistWhenSelected(UsageRight? usageRight)
    {
        if (usageRight == null)
            await throwBusinessException(UsageRightsBusinessMessages.UsageRightNotExists);
    }

    public async Task UsageRightIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        UsageRight? usageRight = await _usageRightRepository.GetAsync(
            predicate: ur => ur.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await UsageRightShouldExistWhenSelected(usageRight);
    }
}