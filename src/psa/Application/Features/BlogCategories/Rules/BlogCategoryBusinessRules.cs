using Application.Features.BlogCategories.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.BlogCategories.Rules;

public class BlogCategoryBusinessRules : BaseBusinessRules
{
    private readonly IBlogCategoryRepository _blogCategoryRepository;
    private readonly ILocalizationService _localizationService;

    public BlogCategoryBusinessRules(IBlogCategoryRepository blogCategoryRepository, ILocalizationService localizationService)
    {
        _blogCategoryRepository = blogCategoryRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, BlogCategoriesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task BlogCategoryShouldExistWhenSelected(BlogCategory? blogCategory)
    {
        if (blogCategory == null)
            await throwBusinessException(BlogCategoriesBusinessMessages.BlogCategoryNotExists);
    }

    public async Task BlogCategoryIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        BlogCategory? blogCategory = await _blogCategoryRepository.GetAsync(
            predicate: bc => bc.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await BlogCategoryShouldExistWhenSelected(blogCategory);
    }
}