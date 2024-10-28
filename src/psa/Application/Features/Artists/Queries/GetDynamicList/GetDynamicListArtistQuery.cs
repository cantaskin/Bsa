using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Application.Services.Artists;
using NArchitecture.Core.Persistence.Dynamic;

namespace Application.Features.Artists.Queries.GetDynamicList;

public class GetDynamicListArtistQuery: IRequest<GetListResponse<GetDynamicListArtistListItemDto>>
{
    public PageRequest PageRequest { get; set; }
    
    public DynamicQuery DynamicQuery { get; set; }

    public class GetDynamicListArtistQueryHandler : IRequestHandler<GetDynamicListArtistQuery, GetListResponse<GetDynamicListArtistListItemDto>>
    {
        private readonly IArtistRepository _artistRepository;
        private readonly IArtistService _artistService;
        private readonly IMapper _mapper;

        public GetDynamicListArtistQueryHandler(IArtistRepository artistRepository, IMapper mapper, IArtistService artistService)
        {
            _artistRepository = artistRepository;
            _mapper = mapper;
            _artistService = artistService;
        }

        public async Task<GetListResponse<GetDynamicListArtistListItemDto>> Handle(GetDynamicListArtistQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Artist> artists = await _artistRepository.GetListByDynamicAsync(
                dynamic: request.DynamicQuery,
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetDynamicListArtistListItemDto> response = _mapper.Map<GetListResponse<GetDynamicListArtistListItemDto>>(artists);

            return response;
        }
    }
}