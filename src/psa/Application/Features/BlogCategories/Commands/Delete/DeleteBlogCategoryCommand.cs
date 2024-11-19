using Application.Features.BlogCategories.Constants;
using Application.Features.BlogCategories.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.BlogCategories.Commands.Delete;

public class DeleteBlogCategoryCommand : IRequest<DeletedBlogCategoryResponse>
{
    public Guid Id { get; set; }

    public class DeleteBlogCategoryCommandHandler : IRequestHandler<DeleteBlogCategoryCommand, DeletedBlogCategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBlogCategoryRepository _blogCategoryRepository;
        private readonly BlogCategoryBusinessRules _blogCategoryBusinessRules;

        public DeleteBlogCategoryCommandHandler(IMapper mapper, IBlogCategoryRepository blogCategoryRepository,
                                         BlogCategoryBusinessRules blogCategoryBusinessRules)
        {
            _mapper = mapper;
            _blogCategoryRepository = blogCategoryRepository;
            _blogCategoryBusinessRules = blogCategoryBusinessRules;
        }

        public async Task<DeletedBlogCategoryResponse> Handle(DeleteBlogCategoryCommand request, CancellationToken cancellationToken)
        {
            BlogCategory? blogCategory = await _blogCategoryRepository.GetAsync(predicate: bc => bc.Id == request.Id, cancellationToken: cancellationToken);
            await _blogCategoryBusinessRules.BlogCategoryShouldExistWhenSelected(blogCategory);

            await _blogCategoryRepository.DeleteAsync(blogCategory!);

            DeletedBlogCategoryResponse response = _mapper.Map<DeletedBlogCategoryResponse>(blogCategory);
            return response;
        }
    }
}