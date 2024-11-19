using NArchitecture.Core.Application.Responses;

namespace Application.Features.RealVoiceProjects.Commands.Delete;

public class DeletedRealVoiceProjectResponse : IResponse
{
    public Guid Id { get; set; }
}