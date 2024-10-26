using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Demoes.Queries.GetList;

public class GetListDemoQuery : IRequest<GetListResponse<GetListDemoListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListDemoQueryHandler : IRequestHandler<GetListDemoQuery, GetListResponse<GetListDemoListItemDto>>
    {
        private readonly IDemoRepository _demoRepository;
        private readonly IMapper _mapper;

        public GetListDemoQueryHandler(IDemoRepository demoRepository, IMapper mapper)
        {
            _demoRepository = demoRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListDemoListItemDto>> Handle(GetListDemoQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Demo> demoes = await _demoRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListDemoListItemDto> response = _mapper.Map<GetListResponse<GetListDemoListItemDto>>(demoes);
            return response;
        }
    }
}