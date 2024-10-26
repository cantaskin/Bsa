using NArchitecture.Core.Application.Responses;

namespace Application.Features.ToneCategories.Commands.Delete;

public class DeletedToneCategoryResponse : IResponse
{
    public Guid Id { get; set; }
}