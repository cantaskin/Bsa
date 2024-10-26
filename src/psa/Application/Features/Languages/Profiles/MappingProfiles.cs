using Application.Features.Languages.Commands.Create;
using Application.Features.Languages.Commands.Delete;
using Application.Features.Languages.Commands.Update;
using Application.Features.Languages.Queries.GetById;
using Application.Features.Languages.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Languages.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateLanguageCommand, Language>();
        CreateMap<Language, CreatedLanguageResponse>();

        CreateMap<UpdateLanguageCommand, Language>();
        CreateMap<Language, UpdatedLanguageResponse>();

        CreateMap<DeleteLanguageCommand, Language>();
        CreateMap<Language, DeletedLanguageResponse>();

        CreateMap<Language, GetByIdLanguageResponse>();

        CreateMap<Language, GetListLanguageListItemDto>();
        CreateMap<IPaginate<Language>, GetListResponse<GetListLanguageListItemDto>>();
    }
}