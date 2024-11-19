using Application.Features.Artists.Rules;
using Application.Features.Languages.Rules;
using Application.Services.FileHelperService;
using Application.Services.Languages;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Collections.ObjectModel;

namespace Application.Features.Artists.Commands.Create;

public class CreateArtistCommand : IRequest<CreatedArtistResponse> 
{
    public required string UserName { get; set; }
    public IFormFile? Photo { get; set; }
    public required string MailAddress { get; set; }
    public IList<string>? YoutubeVideosUrl { get; set; }
    public string? InstVoiceId { get; set; }
    public string? ProfVoiceId { get; set; }
    public required float InstAiUnitPrice { get; set; }
    public required float ProfAiUnitPrice { get; set; }
    public required float RealVoiceStampPrice { get; set; }
    public required Guid ToneCategoryId { get; set; }
    public required GenderEnum Gender { get; set; }
    public required ICollection<Guid> LanguageIds { get; set; }

    public class CreateArtistCommandHandler : IRequestHandler<CreateArtistCommand, CreatedArtistResponse>
    {
        private readonly IMapper _mapper;
        private readonly IArtistRepository _artistRepository;
        private readonly ILanguageService _languageService;
        private readonly LanguageBusinessRules _languageBusinessRules;
        private readonly IFileHelperService _fileHelperService;
        private readonly ArtistBusinessRules _artistBusinessRules;

        public CreateArtistCommandHandler(IMapper mapper, IArtistRepository artistRepository,
                                         ArtistBusinessRules artistBusinessRules, ILanguageService languageService, LanguageBusinessRules languageBusinessRules, IFileHelperService fileHelperService)
        {
            _mapper = mapper;
            _artistRepository = artistRepository;
            _artistBusinessRules = artistBusinessRules;
            _languageService = languageService;
            _languageBusinessRules = languageBusinessRules;
            _fileHelperService = fileHelperService;
        }

        public async Task<CreatedArtistResponse> Handle(CreateArtistCommand request, CancellationToken cancellationToken)
        {
            Artist artist = _mapper.Map<Artist>(request);

            if(request.Photo != null)
                artist.PhotoUrl = await _fileHelperService.UploadImageAsync(request.Photo, FileNames.ArtistImages);

            await _languageService.AddLanguageFromIds(request.LanguageIds, artist.Languages, cancellationToken);

            if (request.Photo != null)
                artist.PhotoUrl = await _fileHelperService.UploadImageAsync(request.Photo, FileNames.ArtistImages);

            await _artistRepository.AddAsync(artist, cancellationToken);

            CreatedArtistResponse response = _mapper.Map<CreatedArtistResponse>(artist);
            return response;
        }
    }
}