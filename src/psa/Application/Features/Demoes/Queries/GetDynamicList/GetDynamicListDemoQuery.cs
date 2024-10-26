using Application.Features.Demoes.Queries.GetList;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
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
        private readonly IMapper _mapper;

        public GetDynamicListDemoQueryHandler(IDemoRepository demoRepository, IMapper mapper)
        {
            _demoRepository = demoRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetDynamicListDemoListItemDto>> Handle(GetDynamicListDemoQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Demo> demoes = await _demoRepository.GetListByDynamicAsync(
                request.DynamicQuery,
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize
            );

            GetListResponse<GetDynamicListDemoListItemDto> response = _mapper.Map<GetListResponse<GetDynamicListDemoListItemDto>>(demoes);
            return response;
        }
    }
}