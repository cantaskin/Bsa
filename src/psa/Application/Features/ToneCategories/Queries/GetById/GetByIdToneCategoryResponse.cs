using NArchitecture.Core.Application.Responses;

namespace Application.Features.ToneCategories.Queries.GetById;

public class GetByIdToneCategoryResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}