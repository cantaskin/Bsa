using Application.Features.Demoes.Queries.GetList;
using Application.Services.Artists;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Dynamic;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Demoes.Queries.GetDynamicList;

public class GetDynamicListDemoQuery : IRequest<GetListResponse<GetDynamicListDemoListItemDto>>
{
    public PageRequest PageRequest { get; set; }
    public DynamicQuery DynamicQuery { get; set; }
    public class GetDynamicListDemoQueryHandler : IRequestHandler<GetDynamicListDemoQuery, GetListResponse<GetDynamicListDemoListItemDto>>
    {
        private readonly IDemoRepository _demoRepository;
        private readonly IArtistRepository _artistRepository;
        private readonly IMapper _mapper;

        public GetDynamicListDemoQueryHandler(IDemoRepository demoRepository, IMapper mapper, IArtistRepository artistRepository)
        {
            _demoRepository = demoRepository;
            _mapper = mapper;
            _artistRepository = artistRepository;
        }

        public async Task<GetListResponse<GetDynamicListDemoListItemDto>> Handle(GetDynamicListDemoQuery request, CancellationToken cancellationToken)
        {

            IPaginate<Demo> demoes = await _demoRepository.GetListByDynamicAsync(
                request.DynamicQuery,
                include: demo => demo.Include(d => d.Artist)
                    .Include(demo => demo.Category)
                    .Include(demo => demo.Language),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize
            );

            GetListResponse<GetDynamicListDemoListItemDto> response = _mapper.Map<GetListResponse<GetDynamicListDemoListItemDto>>(demoes);
            return response;
        }
    }
}