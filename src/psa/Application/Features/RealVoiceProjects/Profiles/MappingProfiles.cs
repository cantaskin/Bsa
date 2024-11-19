using Application.Features.RealVoiceProjects.Commands.Create;
using Application.Features.RealVoiceProjects.Commands.Delete;
using Application.Features.RealVoiceProjects.Commands.Update;
using Application.Features.RealVoiceProjects.Queries.GetById;
using Application.Features.RealVoiceProjects.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.RealVoiceProjects.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateRealVoiceProjectCommand, RealVoiceProject>();
        CreateMap<RealVoiceProject, CreatedRealVoiceProjectResponse>();

        CreateMap<UpdateRealVoiceProjectCommand, RealVoiceProject>()
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null)); ; ;
        CreateMap<RealVoiceProject, UpdatedRealVoiceProjectResponse>();

        CreateMap<DeleteRealVoiceProjectCommand, RealVoiceProject>();
        CreateMap<RealVoiceProject, DeletedRealVoiceProjectResponse>();

        CreateMap<RealVoiceProject, GetByIdRealVoiceProjectResponse>();

        CreateMap<RealVoiceProject, GetListRealVoiceProjectListItemDto>();
        CreateMap<IPaginate<RealVoiceProject>, GetListResponse<GetListRealVoiceProjectListItemDto>>();
    }
}