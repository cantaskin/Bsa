using NArchitecture.Core.Application.Responses;

namespace Application.Features.UsageRights.Queries.GetById;

public class GetByIdUsageRightResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}