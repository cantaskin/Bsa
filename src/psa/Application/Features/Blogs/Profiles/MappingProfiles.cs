using Application.Features.Blogs.Commands.Create;
using Application.Features.Blogs.Commands.Delete;
using Application.Features.Blogs.Commands.Update;
using Application.Features.Blogs.Queries.GetById;
using Application.Features.Blogs.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Blogs.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateBlogCommand, Blog>();
        CreateMap<Blog, CreatedBlogResponse>();

        CreateMap<UpdateBlogCommand, Blog>()
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null)); ; ;
        CreateMap<Blog, UpdatedBlogResponse>();

        CreateMap<DeleteBlogCommand, Blog>();
        CreateMap<Blog, DeletedBlogResponse>();

        CreateMap<Blog, GetByIdBlogResponse>();

        CreateMap<Blog, GetListBlogListItemDto>();
        CreateMap<IPaginate<Blog>, GetListResponse<GetListBlogListItemDto>>();
    }
}