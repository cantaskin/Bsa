using NArchitecture.Core.Application.Responses;

namespace Application.Features.GenderPsas.Queries.GetById;

public class GetByIdGenderPsaResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}