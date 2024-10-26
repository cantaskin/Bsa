using Application.Features.Artists.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Artists.Rules;

public class ArtistBusinessRules : BaseBusinessRules
{
    private readonly IArtistRepository _artistRepository;
    private readonly ILocalizationService _localizationService;

    public ArtistBusinessRules(IArtistRepository artistRepository, ILocalizationService localizationService)
    {
        _artistRepository = artistRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, ArtistsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task ArtistShouldExistWhenSelected(Artist? artist)
    {
        if (artist == null)
            await throwBusinessException(ArtistsBusinessMessages.ArtistNotExists);
    }

    public async Task ArtistIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Artist? artist = await _artistRepository.GetAsync(
            predicate: a => a.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ArtistShouldExistWhenSelected(artist);
    }
}