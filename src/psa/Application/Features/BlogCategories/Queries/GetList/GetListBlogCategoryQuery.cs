using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.BlogCategories.Queries.GetList;

public class GetListBlogCategoryQuery : IRequest<GetListResponse<GetListBlogCategoryListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListBlogCategoryQueryHandler : IRequestHandler<GetListBlogCategoryQuery, GetListResponse<GetListBlogCategoryListItemDto>>
    {
        private readonly IBlogCategoryRepository _blogCategoryRepository;
        private readonly IMapper _mapper;

        public GetListBlogCategoryQueryHandler(IBlogCategoryRepository blogCategoryRepository, IMapper mapper)
        {
            _blogCategoryRepository = blogCategoryRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListBlogCategoryListItemDto>> Handle(GetListBlogCategoryQuery request, CancellationToken cancellationToken)
        {
            IPaginate<BlogCategory> blogCategories = await _blogCategoryRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListBlogCategoryListItemDto> response = _mapper.Map<GetListResponse<GetListBlogCategoryListItemDto>>(blogCategories);
            return response;
        }
    }
}