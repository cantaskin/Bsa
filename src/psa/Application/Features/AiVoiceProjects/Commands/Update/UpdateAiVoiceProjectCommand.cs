using Application.Features.AiVoiceProjects.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Domain.Enums;

namespace Application.Features.AiVoiceProjects.Commands.Update;

public class UpdateAiVoiceProjectCommand : IRequest<UpdatedAiVoiceProjectResponse>
{
    public required Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Text { get; set; }
    public string? Url { get; set; }
    public Guid? ArtistId { get; set; }
    public Guid? LanguageId { get; set; }
    public Guid? UsageRightId { get; set; }
    public ProjectSelectionEnum? ProjectSelection { get; set; }
    public Guid? DemoId { get; set; }

    public class UpdateAiVoiceProjectCommandHandler : IRequestHandler<UpdateAiVoiceProjectCommand, UpdatedAiVoiceProjectResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAiVoiceProjectRepository _aiVoiceProjectRepository;
        private readonly AiVoiceProjectBusinessRules _aiVoiceProjectBusinessRules;

        public UpdateAiVoiceProjectCommandHandler(IMapper mapper, IAiVoiceProjectRepository aiVoiceProjectRepository,
                                         AiVoiceProjectBusinessRules aiVoiceProjectBusinessRules)
        {
            _mapper = mapper;
            _aiVoiceProjectRepository = aiVoiceProjectRepository;
            _aiVoiceProjectBusinessRules = aiVoiceProjectBusinessRules;
        }

        public async Task<UpdatedAiVoiceProjectResponse> Handle(UpdateAiVoiceProjectCommand request, CancellationToken cancellationToken)
        {
            AiVoiceProject? aiVoiceProject = await _aiVoiceProjectRepository.GetAsync(predicate: avp => avp.Id == request.Id, cancellationToken: cancellationToken);
            await _aiVoiceProjectBusinessRules.AiVoiceProjectShouldExistWhenSelected(aiVoiceProject);
            aiVoiceProject = _mapper.Map(request, aiVoiceProject);

            await _aiVoiceProjectRepository.UpdateAsync(aiVoiceProject!, cancellationToken);

            UpdatedAiVoiceProjectResponse response = _mapper.Map<UpdatedAiVoiceProjectResponse>(aiVoiceProject);
            return response;
        }
    }
}