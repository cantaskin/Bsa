using Application.Features.Artists.Rules;
using Application.Services.Artists;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Artists.Queries.GetByIdArtist;

public class GetByIdArtistQuery : IRequest<GetByIdArtistResponse>
{
    public Guid Id { get; set; }

    public class GetByIdArtistQueryHandler : IRequestHandler<GetByIdArtistQuery, GetByIdArtistResponse>
    {
        private readonly IMapper _mapper;
        private readonly IArtistRepository _artistRepository;
        private readonly IArtistService _artistService;
        private readonly ArtistBusinessRules _artistBusinessRules;

        public GetByIdArtistQueryHandler(IMapper mapper, IArtistRepository artistRepository, ArtistBusinessRules artistBusinessRules, IArtistService artistService)
        {
            _mapper = mapper;
            _artistRepository = artistRepository;
            _artistBusinessRules = artistBusinessRules;
            _artistService = artistService;
        }

        public async Task<GetByIdArtistResponse> Handle(GetByIdArtistQuery request, CancellationToken cancellationToken)
        {
            Artist? artist = await _artistRepository.GetAsync(predicate: a => a.Id == request.Id,
                include:query => query.Include(a => a.Languages)
                    .Include(artist => artist.Demos)
                    .Include(artist => artist.ToneCategory), 
                cancellationToken: cancellationToken);
            await _artistBusinessRules.ArtistShouldExistWhenSelected(artist);

            
            GetByIdArtistResponse response = _mapper.Map<GetByIdArtistResponse>(artist);
          //  response.DemoIds = _artistService.GetIdsFromCollection(artist.Demos);
           // response.LanguagesIds = _artistService.GetIdsFromCollection(artist.Languages);

            return response;
        }
    }


}