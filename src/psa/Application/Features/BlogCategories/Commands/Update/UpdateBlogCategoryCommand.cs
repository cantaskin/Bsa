using Application.Features.BlogCategories.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.BlogCategories.Commands.Update;

public class UpdateBlogCategoryCommand : IRequest<UpdatedBlogCategoryResponse>
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }

    public class UpdateBlogCategoryCommandHandler : IRequestHandler<UpdateBlogCategoryCommand, UpdatedBlogCategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBlogCategoryRepository _blogCategoryRepository;
        private readonly BlogCategoryBusinessRules _blogCategoryBusinessRules;

        public UpdateBlogCategoryCommandHandler(IMapper mapper, IBlogCategoryRepository blogCategoryRepository,
                                         BlogCategoryBusinessRules blogCategoryBusinessRules)
        {
            _mapper = mapper;
            _blogCategoryRepository = blogCategoryRepository;
            _blogCategoryBusinessRules = blogCategoryBusinessRules;
        }

        public async Task<UpdatedBlogCategoryResponse> Handle(UpdateBlogCategoryCommand request, CancellationToken cancellationToken)
        {
            BlogCategory? blogCategory = await _blogCategoryRepository.GetAsync(predicate: bc => bc.Id == request.Id, cancellationToken: cancellationToken);
            await _blogCategoryBusinessRules.BlogCategoryShouldExistWhenSelected(blogCategory);
            blogCategory = _mapper.Map(request, blogCategory);

            await _blogCategoryRepository.UpdateAsync(blogCategory!, cancellationToken);

            UpdatedBlogCategoryResponse response = _mapper.Map<UpdatedBlogCategoryResponse>(blogCategory);
            return response;
        }
    }
}