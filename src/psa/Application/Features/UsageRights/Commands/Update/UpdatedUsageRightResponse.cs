using NArchitecture.Core.Application.Responses;

namespace Application.Features.UsageRights.Commands.Update;

public class UpdatedUsageRightResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}