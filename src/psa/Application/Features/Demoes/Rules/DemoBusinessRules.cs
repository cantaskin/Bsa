using Application.Features.Demoes.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Demoes.Rules;

public class DemoBusinessRules : BaseBusinessRules
{
    private readonly IDemoRepository _demoRepository;
    private readonly ILocalizationService _localizationService;

    public DemoBusinessRules(IDemoRepository demoRepository, ILocalizationService localizationService)
    {
        _demoRepository = demoRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, DemoesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task DemoShouldExistWhenSelected(Demo? demo)
    {
        if (demo == null)
            await throwBusinessException(DemoesBusinessMessages.DemoNotExists);
    }

    public async Task DemoIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Demo? demo = await _demoRepository.GetAsync(
            predicate: d => d.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await DemoShouldExistWhenSelected(demo);
    }
}