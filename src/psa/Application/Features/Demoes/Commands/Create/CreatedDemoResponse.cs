using NArchitecture.Core.Application.Responses;

namespace Application.Features.Demoes.Commands.Create;

public class CreatedDemoResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Url { get; set; }
    public Guid LanguageId { get; set; }
    public Guid ArtistId { get; set; }

    public Guid CategoryId { get; set; }
}