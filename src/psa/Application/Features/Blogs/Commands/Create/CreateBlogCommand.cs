using Application.Features.Blogs.Rules;
using Application.Services.FileHelperService;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.Blogs.Commands.Create;

public class CreateBlogCommand : IRequest<CreatedBlogResponse>
{
    public required string Title { get; set; }
    public required string Content { get; set; }
   // public required int ViewCount { get; set; }
    public IFormFile?  File { get; set; }
    public required Guid BlogCategoryId { get; set; }     

    public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand, CreatedBlogResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBlogRepository _blogRepository;
        private readonly IFileHelperService _fileHelperService;
        private readonly BlogBusinessRules _blogBusinessRules;

        public CreateBlogCommandHandler(IMapper mapper, IBlogRepository blogRepository,
                                         BlogBusinessRules blogBusinessRules, IFileHelperService fileHelperService)
        {
            _mapper = mapper;
            _blogRepository = blogRepository;
            _blogBusinessRules = blogBusinessRules;
            _fileHelperService = fileHelperService;
        }

        public async Task<CreatedBlogResponse> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            Blog blog = _mapper.Map<Blog>(request);

            if (request.File != null)
               blog.ThumbnailUrl = await _fileHelperService.UploadImageAsync(request.File, FileNames.BlogImages);

            await _blogRepository.AddAsync(blog, cancellationToken);

            CreatedBlogResponse response = _mapper.Map<CreatedBlogResponse>(blog);
            return response;
        }
    }
}