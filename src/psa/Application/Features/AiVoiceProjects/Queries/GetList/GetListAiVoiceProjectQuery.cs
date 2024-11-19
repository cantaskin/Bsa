using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.AiVoiceProjects.Queries.GetList;

public class GetListAiVoiceProjectQuery : IRequest<GetListResponse<GetListAiVoiceProjectListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListAiVoiceProjectQueryHandler : IRequestHandler<GetListAiVoiceProjectQuery, GetListResponse<GetListAiVoiceProjectListItemDto>>
    {
        private readonly IAiVoiceProjectRepository _aiVoiceProjectRepository;
        private readonly IMapper _mapper;

        public GetListAiVoiceProjectQueryHandler(IAiVoiceProjectRepository aiVoiceProjectRepository, IMapper mapper)
        {
            _aiVoiceProjectRepository = aiVoiceProjectRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListAiVoiceProjectListItemDto>> Handle(GetListAiVoiceProjectQuery request, CancellationToken cancellationToken)
        {
            IPaginate<AiVoiceProject> aiVoiceProjects = await _aiVoiceProjectRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListAiVoiceProjectListItemDto> response = _mapper.Map<GetListResponse<GetListAiVoiceProjectListItemDto>>(aiVoiceProjects);
            return response;
        }
    }
}