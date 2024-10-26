using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Languages.Queries.GetList;

public class GetListLanguageQuery : IRequest<GetListResponse<GetListLanguageListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListLanguageQueryHandler : IRequestHandler<GetListLanguageQuery, GetListResponse<GetListLanguageListItemDto>>
    {
        private readonly ILanguageRepository _languageRepository;
        private readonly IMapper _mapper;

        public GetListLanguageQueryHandler(ILanguageRepository languageRepository, IMapper mapper)
        {
            _languageRepository = languageRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListLanguageListItemDto>> Handle(GetListLanguageQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Language> languages = await _languageRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListLanguageListItemDto> response = _mapper.Map<GetListResponse<GetListLanguageListItemDto>>(languages);
            return response;
        }
    }
}