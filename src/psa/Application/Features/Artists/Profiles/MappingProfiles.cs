using Application.Features.Artists.Commands.Create;
using Application.Features.Artists.Commands.Delete;
using Application.Features.Artists.Commands.Update;
using Application.Features.Artists.Queries.GetByIdAdminArtist;
using Application.Features.Artists.Queries.GetDynamicList;
using Application.Features.Artists.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Artists.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateArtistCommand, Artist>();
        CreateMap<Artist, CreatedArtistResponse>();

        CreateMap<UpdateArtistCommand, Artist>();
        CreateMap<Artist, UpdatedArtistResponse>();

        CreateMap<DeleteArtistCommand, Artist>();
        CreateMap<Artist, DeletedArtistResponse>();

        CreateMap<Artist, GetByIdAdminArtistResponse>();

        CreateMap<Artist, GetListArtistListItemDto>();
        CreateMap<IPaginate<Artist>, GetListResponse<GetListArtistListItemDto>>();

        CreateMap<Artist, GetDynamicListArtistListItemDto>();
        CreateMap<IPaginate<Artist>, GetListResponse<GetDynamicListArtistListItemDto>>();

    }
}