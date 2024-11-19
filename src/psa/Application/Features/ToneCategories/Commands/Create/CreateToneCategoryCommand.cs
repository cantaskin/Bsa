using Application.Features.ToneCategories.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ToneCategories.Commands.Create;

public class CreateToneCategoryCommand : IRequest<CreatedToneCategoryResponse>
{
    public required string Name { get; set; }

    public class CreateToneCategoryCommandHandler : IRequestHandler<CreateToneCategoryCommand, CreatedToneCategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IToneCategoryRepository _toneCategoryRepository;
        private readonly ToneCategoryBusinessRules _toneCategoryBusinessRules;

        public CreateToneCategoryCommandHandler(IMapper mapper, IToneCategoryRepository toneCategoryRepository,
                                         ToneCategoryBusinessRules toneCategoryBusinessRules)
        {
            _mapper = mapper;
            _toneCategoryRepository = toneCategoryRepository;
            _toneCategoryBusinessRules = toneCategoryBusinessRules;
        }

        public async Task<CreatedToneCategoryResponse> Handle(CreateToneCategoryCommand request, CancellationToken cancellationToken)
        {
            ToneCategory toneCategory = _mapper.Map<ToneCategory>(request);

            await _toneCategoryRepository.AddAsync(toneCategory, cancellationToken);

            CreatedToneCategoryResponse response = _mapper.Map<CreatedToneCategoryResponse>(toneCategory);
            return response;
        }
    }
}