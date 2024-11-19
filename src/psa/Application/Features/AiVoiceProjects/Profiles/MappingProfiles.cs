using Application.Features.AiVoiceProjects.Commands.Create;
using Application.Features.AiVoiceProjects.Commands.Delete;
using Application.Features.AiVoiceProjects.Commands.Update;
using Application.Features.AiVoiceProjects.Queries.GetById;
using Application.Features.AiVoiceProjects.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.AiVoiceProjects.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateAiVoiceProjectCommand, AiVoiceProject>();
        CreateMap<AiVoiceProject, CreatedAiVoiceProjectResponse>();

        CreateMap<UpdateAiVoiceProjectCommand, AiVoiceProject>()
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
        CreateMap<AiVoiceProject, UpdatedAiVoiceProjectResponse>();

        CreateMap<DeleteAiVoiceProjectCommand, AiVoiceProject>();
        CreateMap<AiVoiceProject, DeletedAiVoiceProjectResponse>();

        CreateMap<AiVoiceProject, GetByIdAiVoiceProjectResponse>();

        CreateMap<AiVoiceProject, GetListAiVoiceProjectListItemDto>();
        CreateMap<IPaginate<AiVoiceProject>, GetListResponse<GetListAiVoiceProjectListItemDto>>();
    }
}