using Application.Features.AiVoiceProjects.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.AiVoiceProjects.Queries.GetById;

public class GetByIdAiVoiceProjectQuery : IRequest<GetByIdAiVoiceProjectResponse>
{
    public Guid Id { get; set; }

    public class GetByIdAiVoiceProjectQueryHandler : IRequestHandler<GetByIdAiVoiceProjectQuery, GetByIdAiVoiceProjectResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAiVoiceProjectRepository _aiVoiceProjectRepository;
        private readonly AiVoiceProjectBusinessRules _aiVoiceProjectBusinessRules;

        public GetByIdAiVoiceProjectQueryHandler(IMapper mapper, IAiVoiceProjectRepository aiVoiceProjectRepository, AiVoiceProjectBusinessRules aiVoiceProjectBusinessRules)
        {
            _mapper = mapper;
            _aiVoiceProjectRepository = aiVoiceProjectRepository;
            _aiVoiceProjectBusinessRules = aiVoiceProjectBusinessRules;
        }

        public async Task<GetByIdAiVoiceProjectResponse> Handle(GetByIdAiVoiceProjectQuery request, CancellationToken cancellationToken)
        {
            AiVoiceProject? aiVoiceProject = await _aiVoiceProjectRepository.GetAsync(predicate: avp => avp.Id == request.Id, cancellationToken: cancellationToken);
            await _aiVoiceProjectBusinessRules.AiVoiceProjectShouldExistWhenSelected(aiVoiceProject);

            GetByIdAiVoiceProjectResponse response = _mapper.Map<GetByIdAiVoiceProjectResponse>(aiVoiceProject);
            return response;
        }
    }
}