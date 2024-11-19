using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.RealVoiceProjects.Queries.GetList;

public class GetListRealVoiceProjectQuery : IRequest<GetListResponse<GetListRealVoiceProjectListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListRealVoiceProjectQueryHandler : IRequestHandler<GetListRealVoiceProjectQuery, GetListResponse<GetListRealVoiceProjectListItemDto>>
    {
        private readonly IRealVoiceProjectRepository _realVoiceProjectRepository;
        private readonly IMapper _mapper;

        public GetListRealVoiceProjectQueryHandler(IRealVoiceProjectRepository realVoiceProjectRepository, IMapper mapper)
        {
            _realVoiceProjectRepository = realVoiceProjectRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListRealVoiceProjectListItemDto>> Handle(GetListRealVoiceProjectQuery request, CancellationToken cancellationToken)
        {
            IPaginate<RealVoiceProject> realVoiceProjects = await _realVoiceProjectRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListRealVoiceProjectListItemDto> response = _mapper.Map<GetListResponse<GetListRealVoiceProjectListItemDto>>(realVoiceProjects);
            return response;
        }
    }
}