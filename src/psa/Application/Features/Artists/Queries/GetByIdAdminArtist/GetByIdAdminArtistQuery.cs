using Application.Features.Artists.Rules;
using Application.Services.Artists;
using Application.Services.Languages;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Artists.Queries.GetByIdAdminArtist;

public class GetByIdAdminArtistQuery : IRequest<GetByIdAdminArtistResponse>
{
    public Guid Id { get; set; }

    public class GetByIdAdminArtistQueryHandler : IRequestHandler<GetByIdAdminArtistQuery, GetByIdAdminArtistResponse>
    {
        private readonly IMapper _mapper;
        private readonly IArtistRepository _artistRepository;
        private readonly IArtistService _artistService;
        private readonly ArtistBusinessRules _artistBusinessRules;
        private readonly ILanguageService _languageService;

        public GetByIdAdminArtistQueryHandler(IMapper mapper, IArtistRepository artistRepository, ArtistBusinessRules artistBusinessRules, IArtistService artistService, ILanguageService languageService)
        {
            _mapper = mapper;
            _artistRepository = artistRepository;
            _artistBusinessRules = artistBusinessRules;
            _artistService = artistService;
            _languageService = languageService;
        }

        public async Task<GetByIdAdminArtistResponse> Handle(GetByIdAdminArtistQuery request, CancellationToken cancellationToken)
        {
            Artist? artist = await _artistRepository.GetAsync(predicate: a => a.Id == request.Id,
                include: query => query.Include(a => a.Languages).
                    Include(a => a.GenderPsa)
                    .Include(artist => artist.Demos)
                    .Include(artist => artist.ToneCategory),
                cancellationToken: cancellationToken);
            await _artistBusinessRules.ArtistShouldExistWhenSelected(artist);

            
            GetByIdAdminArtistResponse response = _mapper.Map<GetByIdAdminArtistResponse>(artist);
            response.GenderName = artist.GenderPsa.Name;//GenderPsa var mý diye bir fonksiyon yaz
            response.ToneCategoryName = artist.ToneCategory?.Name; //Tonecategory var mý diye yaz 
            response.DemoIds = _artistService.GetIdsFromCollection(artist.Demos);

            ICollection<Guid> languageIds = _artistService.GetIdsFromCollection(artist.Languages);
            foreach (var languageId in languageIds)
            {
                var language = await _languageService.GetAsync(l => l.Id == languageId);

                if (language != null)         //bunu da düzenle
                    response.LanguageNames.Add(language.Name);
            }

            return response;
        }
    }


}