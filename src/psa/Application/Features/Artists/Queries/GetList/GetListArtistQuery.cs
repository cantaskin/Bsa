using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Application.Services.Artists;

namespace Application.Features.Artists.Queries.GetList;

public class GetListArtistQuery : IRequest<GetListResponse<GetListArtistListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListArtistQueryHandler : IRequestHandler<GetListArtistQuery, GetListResponse<GetListArtistListItemDto>>
    {
        private readonly IArtistRepository _artistRepository;
        private readonly IArtistService _artistService;
        private readonly IMapper _mapper;

        public GetListArtistQueryHandler(IArtistRepository artistRepository, IMapper mapper, IArtistService artistService)
        {
            _artistRepository = artistRepository;
            _mapper = mapper;
            _artistService = artistService;
        }

        public async Task<GetListResponse<GetListArtistListItemDto>> Handle(GetListArtistQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Artist> artists = await _artistRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListArtistListItemDto> response = _mapper.Map<GetListResponse<GetListArtistListItemDto>>(artists);

            return response;
        }
    }
}