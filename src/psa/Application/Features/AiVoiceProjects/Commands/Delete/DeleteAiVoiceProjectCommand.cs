using Application.Features.AiVoiceProjects.Constants;
using Application.Features.AiVoiceProjects.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.AiVoiceProjects.Commands.Delete;

public class DeleteAiVoiceProjectCommand : IRequest<DeletedAiVoiceProjectResponse>
{
    public Guid Id { get; set; }

    public class DeleteAiVoiceProjectCommandHandler : IRequestHandler<DeleteAiVoiceProjectCommand, DeletedAiVoiceProjectResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAiVoiceProjectRepository _aiVoiceProjectRepository;
        private readonly AiVoiceProjectBusinessRules _aiVoiceProjectBusinessRules;

        public DeleteAiVoiceProjectCommandHandler(IMapper mapper, IAiVoiceProjectRepository aiVoiceProjectRepository,
                                         AiVoiceProjectBusinessRules aiVoiceProjectBusinessRules)
        {
            _mapper = mapper;
            _aiVoiceProjectRepository = aiVoiceProjectRepository;
            _aiVoiceProjectBusinessRules = aiVoiceProjectBusinessRules;
        }

        public async Task<DeletedAiVoiceProjectResponse> Handle(DeleteAiVoiceProjectCommand request, CancellationToken cancellationToken)
        {
            AiVoiceProject? aiVoiceProject = await _aiVoiceProjectRepository.GetAsync(predicate: avp => avp.Id == request.Id, cancellationToken: cancellationToken);
            await _aiVoiceProjectBusinessRules.AiVoiceProjectShouldExistWhenSelected(aiVoiceProject);

            await _aiVoiceProjectRepository.DeleteAsync(aiVoiceProject!);

            DeletedAiVoiceProjectResponse response = _mapper.Map<DeletedAiVoiceProjectResponse>(aiVoiceProject);
            return response;
        }
    }
}