using Application.Features.BlogCategories.Commands.Create;
using Application.Features.BlogCategories.Commands.Delete;
using Application.Features.BlogCategories.Commands.Update;
using Application.Features.BlogCategories.Queries.GetById;
using Application.Features.BlogCategories.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.BlogCategories.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateBlogCategoryCommand, BlogCategory>();
        CreateMap<BlogCategory, CreatedBlogCategoryResponse>();

        CreateMap<UpdateBlogCategoryCommand, BlogCategory>();
        CreateMap<BlogCategory, UpdatedBlogCategoryResponse>();

        CreateMap<DeleteBlogCategoryCommand, BlogCategory>();
        CreateMap<BlogCategory, DeletedBlogCategoryResponse>();

        CreateMap<BlogCategory, GetByIdBlogCategoryResponse>();

        CreateMap<BlogCategory, GetListBlogCategoryListItemDto>();
        CreateMap<IPaginate<BlogCategory>, GetListResponse<GetListBlogCategoryListItemDto>>();
    }
}