using Application.Features.Artists.Rules;
using Application.Services.Artists;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Artists.Queries.GetByIdAdminArtist;

public class GetByIdAdminArtistQuery : IRequest<GetByIdAdminArtistResponse>
{
    public Guid Id { get; set; }

    public class GetByIdAdminArtistQueryHandler : IRequestHandler<GetByIdAdminArtistQuery, GetByIdAdminArtistResponse>
    {
        private readonly IMapper _mapper;
        private readonly IArtistRepository _artistRepository;
        private readonly IArtistService _artistService;
        private readonly ArtistBusinessRules _artistBusinessRules;

        public GetByIdAdminArtistQueryHandler(IMapper mapper, IArtistRepository artistRepository, ArtistBusinessRules artistBusinessRules, IArtistService artistService)
        {
            _mapper = mapper;
            _artistRepository = artistRepository;
            _artistBusinessRules = artistBusinessRules;
            _artistService = artistService;
        }

        public async Task<GetByIdAdminArtistResponse> Handle(GetByIdAdminArtistQuery request, CancellationToken cancellationToken)
        {
            Artist? artist = await _artistRepository.GetAsync(predicate: a => a.Id == request.Id,include:query => query.Include(a => a.Languages).Include(a => a.Demos), cancellationToken: cancellationToken);
            await _artistBusinessRules.ArtistShouldExistWhenSelected(artist);

            
            GetByIdAdminArtistResponse response = _mapper.Map<GetByIdAdminArtistResponse>(artist);
            response.GenderId = artist.GenderPsaId;
            response.DemoIds = _artistService.GetIdsFromCollection(artist.Demos);
            response.LanguagesIds = _artistService.GetIdsFromCollection(artist.Languages);

            return response;
        }
    }


}