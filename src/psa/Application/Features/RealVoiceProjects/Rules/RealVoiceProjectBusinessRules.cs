using Application.Features.RealVoiceProjects.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.RealVoiceProjects.Rules;

public class RealVoiceProjectBusinessRules : BaseBusinessRules
{
    private readonly IRealVoiceProjectRepository _realVoiceProjectRepository;
    private readonly ILocalizationService _localizationService;

    public RealVoiceProjectBusinessRules(IRealVoiceProjectRepository realVoiceProjectRepository, ILocalizationService localizationService)
    {
        _realVoiceProjectRepository = realVoiceProjectRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, RealVoiceProjectsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task RealVoiceProjectShouldExistWhenSelected(RealVoiceProject? realVoiceProject)
    {
        if (realVoiceProject == null)
            await throwBusinessException(RealVoiceProjectsBusinessMessages.RealVoiceProjectNotExists);
    }

    public async Task RealVoiceProjectIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        RealVoiceProject? realVoiceProject = await _realVoiceProjectRepository.GetAsync(
            predicate: rvp => rvp.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await RealVoiceProjectShouldExistWhenSelected(realVoiceProject);
    }
}