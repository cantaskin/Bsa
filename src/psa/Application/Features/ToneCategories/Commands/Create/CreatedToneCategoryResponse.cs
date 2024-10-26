using NArchitecture.Core.Application.Responses;

namespace Application.Features.ToneCategories.Commands.Create;

public class CreatedToneCategoryResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}