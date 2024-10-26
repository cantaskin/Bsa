using Application.Features.GenderPsas.Commands.Create;
using Application.Features.GenderPsas.Commands.Delete;
using Application.Features.GenderPsas.Commands.Update;
using Application.Features.GenderPsas.Queries.GetById;
using Application.Features.GenderPsas.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.GenderPsas.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateGenderPsaCommand, GenderPsa>();
        CreateMap<GenderPsa, CreatedGenderPsaResponse>();

        CreateMap<UpdateGenderPsaCommand, GenderPsa>();
        CreateMap<GenderPsa, UpdatedGenderPsaResponse>();

        CreateMap<DeleteGenderPsaCommand, GenderPsa>();
        CreateMap<GenderPsa, DeletedGenderPsaResponse>();

        CreateMap<GenderPsa, GetByIdGenderPsaResponse>();

        CreateMap<GenderPsa, GetListGenderPsaListItemDto>();
        CreateMap<IPaginate<GenderPsa>, GetListResponse<GetListGenderPsaListItemDto>>();
    }
}