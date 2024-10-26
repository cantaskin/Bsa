using NArchitecture.Core.Application.Dtos;

namespace Application.Features.GenderPsas.Queries.GetList;

public class GetListGenderPsaListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}