using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.ToneCategories.Queries.GetList;

public class GetListToneCategoryQuery : IRequest<GetListResponse<GetListToneCategoryListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListToneCategoryQueryHandler : IRequestHandler<GetListToneCategoryQuery, GetListResponse<GetListToneCategoryListItemDto>>
    {
        private readonly IToneCategoryRepository _toneCategoryRepository;
        private readonly IMapper _mapper;

        public GetListToneCategoryQueryHandler(IToneCategoryRepository toneCategoryRepository, IMapper mapper)
        {
            _toneCategoryRepository = toneCategoryRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListToneCategoryListItemDto>> Handle(GetListToneCategoryQuery request, CancellationToken cancellationToken)
        {
            IPaginate<ToneCategory> toneCategories = await _toneCategoryRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListToneCategoryListItemDto> response = _mapper.Map<GetListResponse<GetListToneCategoryListItemDto>>(toneCategories);
            return response;
        }
    }
}