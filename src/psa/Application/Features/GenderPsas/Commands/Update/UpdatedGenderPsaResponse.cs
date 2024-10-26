using NArchitecture.Core.Application.Responses;

namespace Application.Features.GenderPsas.Commands.Update;

public class UpdatedGenderPsaResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}