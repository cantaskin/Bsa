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

namespace Application.Features.Artists.Commands.Update;

public class UpdateArtistCommand : IRequest<UpdatedArtistResponse>
{
    public required Guid Id { get; set; }
    public string? UserName { get; set; }
    public IFormFile? Photo { get; set; }
    public string? MailAddress { get; set; }
    public IList<string>? YoutubeVideosUrl { get; set; }
    public string? InstVoiceId { get; set; }
    public string? ProfVoiceId { get; set; }
    public float? InstAiUnitPrice { get; set; }
    public float? ProfAiUnitPrice { get; set; }
    public float? RealVoiceStampPrice { get; set; }
    public Guid? ToneCategoryId { get; set; }
    public GenderEnum? Gender { get; set; }

    public required ICollection<Guid> LanguageIds { get; set; }

    public class UpdateArtistCommandHandler : IRequestHandler<UpdateArtistCommand, UpdatedArtistResponse>
    {
        private readonly IMapper _mapper;
        private readonly IArtistRepository _artistRepository;
        private readonly IFileHelperService _fileHelperService;
        private readonly ILanguageService _languageService;    
        private readonly ArtistBusinessRules _artistBusinessRules;

        public UpdateArtistCommandHandler(IMapper mapper, IArtistRepository artistRepository,
                                         ArtistBusinessRules artistBusinessRules, IFileHelperService fileHelperService, ILanguageService languageService)
        {
            _mapper = mapper;
            _artistRepository = artistRepository;
            _artistBusinessRules = artistBusinessRules;
            _fileHelperService = fileHelperService;
            _languageService = languageService;
        }

        public async Task<UpdatedArtistResponse> Handle(UpdateArtistCommand request, CancellationToken cancellationToken)
        {
            Artist? artist = await _artistRepository.GetAsync(predicate: a => a.Id == request.Id, cancellationToken: cancellationToken);
            await _artistBusinessRules.ArtistShouldExistWhenSelected(artist);
            artist = _mapper.Map(request, artist);

            await _languageService.AddLanguageFromIds(request.LanguageIds, artist!.Languages, cancellationToken);

            if (request.Photo != null)
                    artist.PhotoUrl = await _fileHelperService.UploadImageAsync(request.Photo, FileNames.ArtistImages);

            await _artistRepository.UpdateAsync(artist!, cancellationToken);

            UpdatedArtistResponse response = _mapper.Map<UpdatedArtistResponse>(artist);
            return response;
        }
    }
}