using NArchitecture.Core.Application.Responses;

namespace Application.Features.ToneCategories.Commands.Update;

public class UpdatedToneCategoryResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}