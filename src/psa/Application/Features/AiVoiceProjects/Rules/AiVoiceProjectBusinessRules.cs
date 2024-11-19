using Application.Features.AiVoiceProjects.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.AiVoiceProjects.Rules;

public class AiVoiceProjectBusinessRules : BaseBusinessRules
{
    private readonly IAiVoiceProjectRepository _aiVoiceProjectRepository;
    private readonly ILocalizationService _localizationService;

    public AiVoiceProjectBusinessRules(IAiVoiceProjectRepository aiVoiceProjectRepository, ILocalizationService localizationService)
    {
        _aiVoiceProjectRepository = aiVoiceProjectRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, AiVoiceProjectsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task AiVoiceProjectShouldExistWhenSelected(AiVoiceProject? aiVoiceProject)
    {
        if (aiVoiceProject == null)
            await throwBusinessException(AiVoiceProjectsBusinessMessages.AiVoiceProjectNotExists);
    }

    public async Task AiVoiceProjectIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        AiVoiceProject? aiVoiceProject = await _aiVoiceProjectRepository.GetAsync(
            predicate: avp => avp.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await AiVoiceProjectShouldExistWhenSelected(aiVoiceProject);
    }
}