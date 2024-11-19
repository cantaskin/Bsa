using Application.Features.Artists.Commands.Create;
using Application.Features.Artists.Commands.Delete;
using Application.Features.Artists.Commands.Update;
using Application.Features.Artists.Queries.GetByIdAdminArtist;
using Application.Features.Artists.Queries.GetByIdArtist;
using Application.Features.Artists.Queries.GetDynamicList;
using Application.Features.Artists.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using Domain.Enums;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Artists.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateArtistCommand, Artist>();
        CreateMap<Artist, CreatedArtistResponse>();

        CreateMap<UpdateArtistCommand, Artist>()
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null)); ;
        CreateMap<Artist, UpdatedArtistResponse>();

        CreateMap<DeleteArtistCommand, Artist>();
        CreateMap<Artist, DeletedArtistResponse>();

        CreateMap<Artist, GetByIdAdminArtistResponse>()
            .ForMember(dest => dest.GenderName, opt => opt.MapFrom(artist => artist.Gender.GetEnumDescription()))
            .ForMember(dest => dest.ToneCategoryName, opt => opt.MapFrom(artist => artist.ToneCategory.Name))
            .ForMember(dest => dest.LanguageNames, opt => opt.MapFrom(artist => artist.Languages.Select(language => language.Name).ToList()))
            .ForMember(dest => dest.DemoIds, opt => opt.MapFrom(artist => artist.Demos.Select(demo => demo.Id).ToList()));

        CreateMap<Artist, GetByIdArtistResponse>()
            .ForMember(dest => dest.GenderName, opt => opt.MapFrom(artist => artist.Gender.GetEnumDescription()))
            .ForMember(dest => dest.ToneCategoryName,opt => opt.MapFrom(artist => artist.ToneCategory.Name))
            .ForMember(dest => dest.LanguageNames, opt => opt.MapFrom(artist => artist.Languages.Select(language => language.Name).ToList()))
            .ForMember(dest => dest.DemoIds, opt => opt.MapFrom(artist => artist.Demos.Select(demo => demo.Id).ToList()));

        CreateMap<Artist, GetListArtistListItemDto>();
        CreateMap<IPaginate<Artist>, GetListResponse<GetListArtistListItemDto>>();

        CreateMap<Artist, GetDynamicListArtistListItemDto>();
        CreateMap<IPaginate<Artist>, GetListResponse<GetDynamicListArtistListItemDto>>();

    }
}