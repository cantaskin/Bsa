using Application.Features.UsageRights.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.UsageRights.Queries.GetById;

public class GetByIdUsageRightQuery : IRequest<GetByIdUsageRightResponse>
{
    public Guid Id { get; set; }

    public class GetByIdUsageRightQueryHandler : IRequestHandler<GetByIdUsageRightQuery, GetByIdUsageRightResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUsageRightRepository _usageRightRepository;
        private readonly UsageRightBusinessRules _usageRightBusinessRules;

        public GetByIdUsageRightQueryHandler(IMapper mapper, IUsageRightRepository usageRightRepository, UsageRightBusinessRules usageRightBusinessRules)
        {
            _mapper = mapper;
            _usageRightRepository = usageRightRepository;
            _usageRightBusinessRules = usageRightBusinessRules;
        }

        public async Task<GetByIdUsageRightResponse> Handle(GetByIdUsageRightQuery request, CancellationToken cancellationToken)
        {
            UsageRight? usageRight = await _usageRightRepository.GetAsync(predicate: ur => ur.Id == request.Id, cancellationToken: cancellationToken);
            await _usageRightBusinessRules.UsageRightShouldExistWhenSelected(usageRight);

            GetByIdUsageRightResponse response = _mapper.Map<GetByIdUsageRightResponse>(usageRight);
            return response;
        }
    }
}