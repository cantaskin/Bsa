using Application.Features.BlogCategories.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.BlogCategories;

public class BlogCategoryManager : IBlogCategoryService
{
    private readonly IBlogCategoryRepository _blogCategoryRepository;
    private readonly BlogCategoryBusinessRules _blogCategoryBusinessRules;

    public BlogCategoryManager(IBlogCategoryRepository blogCategoryRepository, BlogCategoryBusinessRules blogCategoryBusinessRules)
    {
        _blogCategoryRepository = blogCategoryRepository;
        _blogCategoryBusinessRules = blogCategoryBusinessRules;
    }

    public async Task<BlogCategory?> GetAsync(
        Expression<Func<BlogCategory, bool>> predicate,
        Func<IQueryable<BlogCategory>, IIncludableQueryable<BlogCategory, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        BlogCategory? blogCategory = await _blogCategoryRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return blogCategory;
    }

    public async Task<IPaginate<BlogCategory>?> GetListAsync(
        Expression<Func<BlogCategory, bool>>? predicate = null,
        Func<IQueryable<BlogCategory>, IOrderedQueryable<BlogCategory>>? orderBy = null,
        Func<IQueryable<BlogCategory>, IIncludableQueryable<BlogCategory, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<BlogCategory> blogCategoryList = await _blogCategoryRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return blogCategoryList;
    }

    public async Task<BlogCategory> AddAsync(BlogCategory blogCategory)
    {
        BlogCategory addedBlogCategory = await _blogCategoryRepository.AddAsync(blogCategory);

        return addedBlogCategory;
    }

    public async Task<BlogCategory> UpdateAsync(BlogCategory blogCategory)
    {
        BlogCategory updatedBlogCategory = await _blogCategoryRepository.UpdateAsync(blogCategory);

        return updatedBlogCategory;
    }

    public async Task<BlogCategory> DeleteAsync(BlogCategory blogCategory, bool permanent = false)
    {
        BlogCategory deletedBlogCategory = await _blogCategoryRepository.DeleteAsync(blogCategory);

        return deletedBlogCategory;
    }
}
