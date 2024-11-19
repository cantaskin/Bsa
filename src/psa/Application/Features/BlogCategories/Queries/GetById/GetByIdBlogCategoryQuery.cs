using Application.Features.BlogCategories.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.BlogCategories.Queries.GetById;

public class GetByIdBlogCategoryQuery : IRequest<GetByIdBlogCategoryResponse>
{
    public Guid Id { get; set; }

    public class GetByIdBlogCategoryQueryHandler : IRequestHandler<GetByIdBlogCategoryQuery, GetByIdBlogCategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBlogCategoryRepository _blogCategoryRepository;
        private readonly BlogCategoryBusinessRules _blogCategoryBusinessRules;

        public GetByIdBlogCategoryQueryHandler(IMapper mapper, IBlogCategoryRepository blogCategoryRepository, BlogCategoryBusinessRules blogCategoryBusinessRules)
        {
            _mapper = mapper;
            _blogCategoryRepository = blogCategoryRepository;
            _blogCategoryBusinessRules = blogCategoryBusinessRules;
        }

        public async Task<GetByIdBlogCategoryResponse> Handle(GetByIdBlogCategoryQuery request, CancellationToken cancellationToken)
        {
            BlogCategory? blogCategory = await _blogCategoryRepository.GetAsync(predicate: bc => bc.Id == request.Id, cancellationToken: cancellationToken);
            await _blogCategoryBusinessRules.BlogCategoryShouldExistWhenSelected(blogCategory);

            GetByIdBlogCategoryResponse response = _mapper.Map<GetByIdBlogCategoryResponse>(blogCategory);
            return response;
        }
    }
}