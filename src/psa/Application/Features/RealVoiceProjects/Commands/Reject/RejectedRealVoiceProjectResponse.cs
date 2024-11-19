using NArchitecture.Core.Application.Responses;

namespace Application.Features.RealVoiceProjects.Commands.Reject;

public class RejectedRealVoiceProjectResponse : IResponse
{
    public Guid Id { get; set; }
}