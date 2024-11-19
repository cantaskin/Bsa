using Application.Features.Blogs.Rules;
using Application.Services.FileHelperService;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.Blogs.Commands.Update;

public class UpdateBlogCommand : IRequest<UpdatedBlogResponse>
{
    public required Guid Id { get; set; }
    public string? Title { get; set; }
    public string? Content { get; set; }
    public IFormFile? File { get; set; }

    public required Guid BlogCategoryId { get; set; }
    public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand, UpdatedBlogResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBlogRepository _blogRepository;
        private readonly BlogBusinessRules _blogBusinessRules;
        private readonly IFileHelperService _fileHelperService;

        public UpdateBlogCommandHandler(IMapper mapper, IBlogRepository blogRepository,
                                         BlogBusinessRules blogBusinessRules, IFileHelperService fileHelperService)
        {
            _mapper = mapper;
            _blogRepository = blogRepository;
            _blogBusinessRules = blogBusinessRules;
            _fileHelperService = fileHelperService;
        }

        public async Task<UpdatedBlogResponse> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            Blog? blog = await _blogRepository.GetAsync(predicate: b => b.Id == request.Id, cancellationToken: cancellationToken);
            await _blogBusinessRules.BlogShouldExistWhenSelected(blog);
            blog = _mapper.Map(request, blog);

            if (request.File != null)
                blog.ThumbnailUrl = await _fileHelperService.UploadImageAsync(request.File, FileNames.BlogImages);


            await _blogRepository.UpdateAsync(blog!);

            UpdatedBlogResponse response = _mapper.Map<UpdatedBlogResponse>(blog);
            return response;
        }
    }
}