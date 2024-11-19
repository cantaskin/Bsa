using NArchitecture.Core.Application.Responses;

namespace Application.Features.UsageRights.Commands.Delete;

public class DeletedUsageRightResponse : IResponse
{
    public Guid Id { get; set; }
}