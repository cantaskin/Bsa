using Application.Features.ToneCategories.Constants;
using Application.Features.ToneCategories.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ToneCategories.Commands.Delete;

public class DeleteToneCategoryCommand : IRequest<DeletedToneCategoryResponse>
{
    public Guid Id { get; set; }

    public class DeleteToneCategoryCommandHandler : IRequestHandler<DeleteToneCategoryCommand, DeletedToneCategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IToneCategoryRepository _toneCategoryRepository;
        private readonly ToneCategoryBusinessRules _toneCategoryBusinessRules;

        public DeleteToneCategoryCommandHandler(IMapper mapper, IToneCategoryRepository toneCategoryRepository,
                                         ToneCategoryBusinessRules toneCategoryBusinessRules)
        {
            _mapper = mapper;
            _toneCategoryRepository = toneCategoryRepository;
            _toneCategoryBusinessRules = toneCategoryBusinessRules;
        }

        public async Task<DeletedToneCategoryResponse> Handle(DeleteToneCategoryCommand request, CancellationToken cancellationToken)
        {
            ToneCategory? toneCategory = await _toneCategoryRepository.GetAsync(predicate: tc => tc.Id == request.Id, cancellationToken: cancellationToken);
            await _toneCategoryBusinessRules.ToneCategoryShouldExistWhenSelected(toneCategory);

            await _toneCategoryRepository.DeleteAsync(toneCategory!);

            DeletedToneCategoryResponse response = _mapper.Map<DeletedToneCategoryResponse>(toneCategory);
            return response;
        }
    }
}