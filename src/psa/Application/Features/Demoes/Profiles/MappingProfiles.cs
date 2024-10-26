using Application.Features.Demoes.Commands.Create;
using Application.Features.Demoes.Commands.Delete;
using Application.Features.Demoes.Commands.Update;
using Application.Features.Demoes.Queries.GetById;
using Application.Features.Demoes.Queries.GetDynamicList;
using Application.Features.Demoes.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Demoes.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateDemoCommand, Demo>();
        CreateMap<Demo, CreatedDemoResponse>();

        CreateMap<UpdateDemoCommand, Demo>();
        CreateMap<Demo, UpdatedDemoResponse>();

        CreateMap<DeleteDemoCommand, Demo>();
        CreateMap<Demo, DeletedDemoResponse>();

        CreateMap<Demo, GetByIdDemoResponse>();

        CreateMap<Demo, GetDynamicListDemoListItemDto>();
        CreateMap<IPaginate<Demo>, GetListResponse<GetDynamicListDemoListItemDto>>();
    }
}