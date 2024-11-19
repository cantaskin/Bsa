using NArchitecture.Core.Application.Dtos;

namespace Application.Features.UsageRights.Queries.GetList;

public class GetListUsageRightListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}