using Application.Features.ToneCategories.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ToneCategories.Commands.Update;

public class UpdateToneCategoryCommand : IRequest<UpdatedToneCategoryResponse>
{
    public Guid Id { get; set; }
    public required string Name { get; set; }

    public class UpdateToneCategoryCommandHandler : IRequestHandler<UpdateToneCategoryCommand, UpdatedToneCategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IToneCategoryRepository _toneCategoryRepository;
        private readonly ToneCategoryBusinessRules _toneCategoryBusinessRules;

        public UpdateToneCategoryCommandHandler(IMapper mapper, IToneCategoryRepository toneCategoryRepository,
                                         ToneCategoryBusinessRules toneCategoryBusinessRules)
        {
            _mapper = mapper;
            _toneCategoryRepository = toneCategoryRepository;
            _toneCategoryBusinessRules = toneCategoryBusinessRules;
        }

        public async Task<UpdatedToneCategoryResponse> Handle(UpdateToneCategoryCommand request, CancellationToken cancellationToken)
        {
            ToneCategory? toneCategory = await _toneCategoryRepository.GetAsync(predicate: tc => tc.Id == request.Id, cancellationToken: cancellationToken);
            await _toneCategoryBusinessRules.ToneCategoryShouldExistWhenSelected(toneCategory);
            toneCategory = _mapper.Map(request, toneCategory);

            await _toneCategoryRepository.UpdateAsync(toneCategory!);

            UpdatedToneCategoryResponse response = _mapper.Map<UpdatedToneCategoryResponse>(toneCategory);
            return response;
        }
    }
}