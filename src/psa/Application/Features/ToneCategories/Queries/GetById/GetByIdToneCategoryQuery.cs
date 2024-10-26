using Application.Features.ToneCategories.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ToneCategories.Queries.GetById;

public class GetByIdToneCategoryQuery : IRequest<GetByIdToneCategoryResponse>
{
    public Guid Id { get; set; }

    public class GetByIdToneCategoryQueryHandler : IRequestHandler<GetByIdToneCategoryQuery, GetByIdToneCategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IToneCategoryRepository _toneCategoryRepository;
        private readonly ToneCategoryBusinessRules _toneCategoryBusinessRules;

        public GetByIdToneCategoryQueryHandler(IMapper mapper, IToneCategoryRepository toneCategoryRepository, ToneCategoryBusinessRules toneCategoryBusinessRules)
        {
            _mapper = mapper;
            _toneCategoryRepository = toneCategoryRepository;
            _toneCategoryBusinessRules = toneCategoryBusinessRules;
        }

        public async Task<GetByIdToneCategoryResponse> Handle(GetByIdToneCategoryQuery request, CancellationToken cancellationToken)
        {
            ToneCategory? toneCategory = await _toneCategoryRepository.GetAsync(predicate: tc => tc.Id == request.Id, cancellationToken: cancellationToken);
            await _toneCategoryBusinessRules.ToneCategoryShouldExistWhenSelected(toneCategory);

            GetByIdToneCategoryResponse response = _mapper.Map<GetByIdToneCategoryResponse>(toneCategory);
            return response;
        }
    }
}