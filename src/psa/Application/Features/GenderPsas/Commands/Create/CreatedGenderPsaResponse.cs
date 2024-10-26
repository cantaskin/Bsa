using NArchitecture.Core.Application.Responses;

namespace Application.Features.GenderPsas.Commands.Create;

public class CreatedGenderPsaResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}