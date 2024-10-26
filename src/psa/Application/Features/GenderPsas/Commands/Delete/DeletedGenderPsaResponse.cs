using NArchitecture.Core.Application.Responses;

namespace Application.Features.GenderPsas.Commands.Delete;

public class DeletedGenderPsaResponse : IResponse
{
    public Guid Id { get; set; }
}