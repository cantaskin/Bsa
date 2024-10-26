using Application.Features.ToneCategories.Commands.Create;
using Application.Features.ToneCategories.Commands.Delete;
using Application.Features.ToneCategories.Commands.Update;
using Application.Features.ToneCategories.Queries.GetById;
using Application.Features.ToneCategories.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.ToneCategories.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateToneCategoryCommand, ToneCategory>();
        CreateMap<ToneCategory, CreatedToneCategoryResponse>();

        CreateMap<UpdateToneCategoryCommand, ToneCategory>();
        CreateMap<ToneCategory, UpdatedToneCategoryResponse>();

        CreateMap<DeleteToneCategoryCommand, ToneCategory>();
        CreateMap<ToneCategory, DeletedToneCategoryResponse>();

        CreateMap<ToneCategory, GetByIdToneCategoryResponse>();

        CreateMap<ToneCategory, GetListToneCategoryListItemDto>();
        CreateMap<IPaginate<ToneCategory>, GetListResponse<GetListToneCategoryListItemDto>>();
    }
}