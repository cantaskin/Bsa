using NArchitecture.Core.Application.Responses;

namespace Application.Features.Demoes.Queries.GetById;

public class GetByIdDemoResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Url { get; set; }
    public Guid LanguageId { get; set; }
    public Guid CategoryId { get; set; }
}