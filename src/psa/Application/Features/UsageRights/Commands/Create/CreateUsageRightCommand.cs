using Application.Features.UsageRights.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.UsageRights.Commands.Create;

public class CreateUsageRightCommand : IRequest<CreatedUsageRightResponse>
{
    public required string Name { get; set; }
    public required string Description { get; set; }

    public class CreateUsageRightCommandHandler : IRequestHandler<CreateUsageRightCommand, CreatedUsageRightResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUsageRightRepository _usageRightRepository;
        private readonly UsageRightBusinessRules _usageRightBusinessRules;

        public CreateUsageRightCommandHandler(IMapper mapper, IUsageRightRepository usageRightRepository,
                                         UsageRightBusinessRules usageRightBusinessRules)
        {
            _mapper = mapper;
            _usageRightRepository = usageRightRepository;
            _usageRightBusinessRules = usageRightBusinessRules;
        }

        public async Task<CreatedUsageRightResponse> Handle(CreateUsageRightCommand request, CancellationToken cancellationToken)
        {
            UsageRight usageRight = _mapper.Map<UsageRight>(request);

            await _usageRightRepository.AddAsync(usageRight, cancellationToken);

            CreatedUsageRightResponse response = _mapper.Map<CreatedUsageRightResponse>(usageRight);
            return response;
        }
    }
}