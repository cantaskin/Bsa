using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.UsageRights.Queries.GetList;

public class GetListUsageRightQuery : IRequest<GetListResponse<GetListUsageRightListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListUsageRightQueryHandler : IRequestHandler<GetListUsageRightQuery, GetListResponse<GetListUsageRightListItemDto>>
    {
        private readonly IUsageRightRepository _usageRightRepository;
        private readonly IMapper _mapper;

        public GetListUsageRightQueryHandler(IUsageRightRepository usageRightRepository, IMapper mapper)
        {
            _usageRightRepository = usageRightRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListUsageRightListItemDto>> Handle(GetListUsageRightQuery request, CancellationToken cancellationToken)
        {
            IPaginate<UsageRight> usageRights = await _usageRightRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListUsageRightListItemDto> response = _mapper.Map<GetListResponse<GetListUsageRightListItemDto>>(usageRights);
            return response;
        }
    }
}