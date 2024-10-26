using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.GenderPsas.Queries.GetList;

public class GetListGenderPsaQuery : IRequest<GetListResponse<GetListGenderPsaListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListGenderPsaQueryHandler : IRequestHandler<GetListGenderPsaQuery, GetListResponse<GetListGenderPsaListItemDto>>
    {
        private readonly IGenderPsaRepository _genderPsaRepository;
        private readonly IMapper _mapper;

        public GetListGenderPsaQueryHandler(IGenderPsaRepository genderPsaRepository, IMapper mapper)
        {
            _genderPsaRepository = genderPsaRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListGenderPsaListItemDto>> Handle(GetListGenderPsaQuery request, CancellationToken cancellationToken)
        {
            IPaginate<GenderPsa> genderPsas = await _genderPsaRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListGenderPsaListItemDto> response = _mapper.Map<GetListResponse<GetListGenderPsaListItemDto>>(genderPsas);
            return response;
        }
    }
}