using Application.Features.Artists.Constants;
using Application.Features.Artists.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Artists.Commands.Delete;

public class DeleteArtistCommand : IRequest<DeletedArtistResponse>
{
    public Guid Id { get; set; }

    public class DeleteArtistCommandHandler : IRequestHandler<DeleteArtistCommand, DeletedArtistResponse>
    {
        private readonly IMapper _mapper;
        private readonly IArtistRepository _artistRepository;
        private readonly ArtistBusinessRules _artistBusinessRules;

        public DeleteArtistCommandHandler(IMapper mapper, IArtistRepository artistRepository,
                                         ArtistBusinessRules artistBusinessRules)
        {
            _mapper = mapper;
            _artistRepository = artistRepository;
            _artistBusinessRules = artistBusinessRules;
        }

        public async Task<DeletedArtistResponse> Handle(DeleteArtistCommand request, CancellationToken cancellationToken)
        {
            Artist? artist = await _artistRepository.GetAsync(predicate: a => a.Id == request.Id, cancellationToken: cancellationToken);
            await _artistBusinessRules.ArtistShouldExistWhenSelected(artist);

            await _artistRepository.DeleteAsync(artist!);

            DeletedArtistResponse response = _mapper.Map<DeletedArtistResponse>(artist);
            return response;
        }
    }
}