using Application.Features.Artists.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Artists.Commands.Update;

public class UpdateArtistCommand : IRequest<UpdatedArtistResponse>
{
    public Guid Id { get; set; }
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

    public class UpdateArtistCommandHandler : IRequestHandler<UpdateArtistCommand, UpdatedArtistResponse>
    {
        private readonly IMapper _mapper;
        private readonly IArtistRepository _artistRepository;
        private readonly ArtistBusinessRules _artistBusinessRules;

        public UpdateArtistCommandHandler(IMapper mapper, IArtistRepository artistRepository,
                                         ArtistBusinessRules artistBusinessRules)
        {
            _mapper = mapper;
            _artistRepository = artistRepository;
            _artistBusinessRules = artistBusinessRules;
        }

        public async Task<UpdatedArtistResponse> Handle(UpdateArtistCommand request, CancellationToken cancellationToken)
        {
            Artist? artist = await _artistRepository.GetAsync(predicate: a => a.Id == request.Id, cancellationToken: cancellationToken);
            await _artistBusinessRules.ArtistShouldExistWhenSelected(artist);
            artist = _mapper.Map(request, artist);

            await _artistRepository.UpdateAsync(artist!);

            UpdatedArtistResponse response = _mapper.Map<UpdatedArtistResponse>(artist);
            return response;
        }
    }
}