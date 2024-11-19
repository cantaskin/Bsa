using NArchitecture.Core.Application.Responses;

namespace Application.Features.RealVoiceProjects.Commands.Finalize;

public class FinalizedRealVoiceProjectResponse : IResponse
{
    public Guid Id { get; set; }
    public string? Url { get; set; }
}