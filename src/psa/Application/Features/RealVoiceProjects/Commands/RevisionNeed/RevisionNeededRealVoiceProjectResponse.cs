using NArchitecture.Core.Application.Responses;

namespace Application.Features.RealVoiceProjects.Commands.RevisionNeed;

public class RevisionNeededRealVoiceProjectResponse : IResponse
{
    public Guid Id { get; set; }
}