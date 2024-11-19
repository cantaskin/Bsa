using Application.Features.UsageRights.Commands.Create;
using Application.Features.UsageRights.Commands.Delete;
using Application.Features.UsageRights.Commands.Update;
using Application.Features.UsageRights.Queries.GetById;
using Application.Features.UsageRights.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.UsageRights.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateUsageRightCommand, UsageRight>();
        CreateMap<UsageRight, CreatedUsageRightResponse>();

        CreateMap<UpdateUsageRightCommand, UsageRight>();
        CreateMap<UsageRight, UpdatedUsageRightResponse>();

        CreateMap<DeleteUsageRightCommand, UsageRight>();
        CreateMap<UsageRight, DeletedUsageRightResponse>();

        CreateMap<UsageRight, GetByIdUsageRightResponse>();

        CreateMap<UsageRight, GetListUsageRightListItemDto>();
        CreateMap<IPaginate<UsageRight>, GetListResponse<GetListUsageRightListItemDto>>();
    }
}