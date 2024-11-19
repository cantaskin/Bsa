using NArchitecture.Core.Application.Responses;

namespace Application.Features.UsageRights.Commands.Create;

public class CreatedUsageRightResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}