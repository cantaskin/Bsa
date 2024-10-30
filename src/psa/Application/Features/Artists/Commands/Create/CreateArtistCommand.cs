using Application.Features.Artists.Rules;
using Application.Features.Languages.Rules;
using Application.Services.Languages;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Collections.ObjectModel;

namespace Application.Features.Artists.Commands.Create;

public class CreateArtistCommand : IRequest<CreatedArtistResponse> 
{
    public required string UserName { get; set; }
    public string? PhotoUrl { get; set; }
    public required string MailAddress { get; set; }
    public string? YoutubeAddress { get; set; }
    public required float InstAiUnitPrice { get; set; }
    public required float ProfAiUnitPrice { get; set; }
    public required float RealVoiceStampPrice { get; set; }
    public required Guid ToneCategoryId { get; set; }
    public required Guid GenderPsaId { get; set; }
    
    public required ICollection<Guid> LanguageIds { get; set; }

    public class CreateArtistCommandHandler : IRequestHandler<CreateArtistCommand, CreatedArtistResponse>
    {
        private readonly IMapper _mapper;
        private readonly IArtistRepository _artistRepository;
        private readonly ILanguageService _languageService;
        private readonly LanguageBusinessRules _languageBusinessRules;
        private readonly ArtistBusinessRules _artistBusinessRules;

        public CreateArtistCommandHandler(IMapper mapper, IArtistRepository artistRepository,
                                         ArtistBusinessRules artistBusinessRules, ILanguageService languageService, LanguageBusinessRules languageBusinessRules)
        {
            _mapper = mapper;
            _artistRepository = artistRepository;
            _artistBusinessRules = artistBusinessRules;
            _languageService = languageService;
            _languageBusinessRules = languageBusinessRules;
        }

        public async Task<CreatedArtistResponse> Handle(CreateArtistCommand request, CancellationToken cancellationToken)
        {
            Artist artist = _mapper.Map<Artist>(request);

            ICollection<Language> languages = new List<Language>();

            foreach (var languageId in request.LanguageIds)
            {
                await _languageBusinessRules.LanguageIdShouldExistWhenSelected(languageId, cancellationToken);
                var language = await _languageService.GetAsync(l => l.Id == languageId, cancellationToken: cancellationToken);
                if (language != null) 
                    languages.Add(language);
            }

            artist.Languages = languages;
            
            await _artistRepository.AddAsync(artist);

            CreatedArtistResponse response = _mapper.Map<CreatedArtistResponse>(artist);
            return response;
        }
    }
}