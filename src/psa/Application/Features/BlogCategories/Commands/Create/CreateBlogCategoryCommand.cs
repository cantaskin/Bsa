using Application.Features.BlogCategories.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.BlogCategories.Commands.Create;

public class CreateBlogCategoryCommand : IRequest<CreatedBlogCategoryResponse>
{
    public required string Name { get; set; }

    public class CreateBlogCategoryCommandHandler : IRequestHandler<CreateBlogCategoryCommand, CreatedBlogCategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBlogCategoryRepository _blogCategoryRepository;
        private readonly BlogCategoryBusinessRules _blogCategoryBusinessRules;

        public CreateBlogCategoryCommandHandler(IMapper mapper, IBlogCategoryRepository blogCategoryRepository,
                                         BlogCategoryBusinessRules blogCategoryBusinessRules)
        {
            _mapper = mapper;
            _blogCategoryRepository = blogCategoryRepository;
            _blogCategoryBusinessRules = blogCategoryBusinessRules;
        }

        public async Task<CreatedBlogCategoryResponse> Handle(CreateBlogCategoryCommand request, CancellationToken cancellationToken)
        {
            BlogCategory blogCategory = _mapper.Map<BlogCategory>(request);

            await _blogCategoryRepository.AddAsync(blogCategory, cancellationToken);

            CreatedBlogCategoryResponse response = _mapper.Map<CreatedBlogCategoryResponse>(blogCategory);
            return response;
        }
    }
}