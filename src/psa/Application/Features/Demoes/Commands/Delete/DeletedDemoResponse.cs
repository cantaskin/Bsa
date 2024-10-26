using NArchitecture.Core.Application.Responses;

namespace Application.Features.Demoes.Commands.Delete;

public class DeletedDemoResponse : IResponse
{
    public Guid Id { get; set; }
}