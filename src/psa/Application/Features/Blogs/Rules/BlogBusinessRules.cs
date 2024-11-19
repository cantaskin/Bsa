using Application.Features.Blogs.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Blogs.Rules;

public class BlogBusinessRules : BaseBusinessRules
{
    private readonly IBlogRepository _blogRepository;
    private readonly ILocalizationService _localizationService;

    public BlogBusinessRules(IBlogRepository blogRepository, ILocalizationService localizationService)
    {
        _blogRepository = blogRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, BlogsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task BlogShouldExistWhenSelected(Blog? blog)
    {
        if (blog == null)
            await throwBusinessException(BlogsBusinessMessages.BlogNotExists);
    }

    public async Task BlogIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Blog? blog = await _blogRepository.GetAsync(
            predicate: b => b.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await BlogShouldExistWhenSelected(blog);
    }
}