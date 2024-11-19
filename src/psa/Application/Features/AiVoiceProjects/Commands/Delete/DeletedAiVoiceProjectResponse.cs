using NArchitecture.Core.Application.Responses;

namespace Application.Features.AiVoiceProjects.Commands.Delete;

public class DeletedAiVoiceProjectResponse : IResponse
{
    public Guid Id { get; set; }
}