using Application.Features.UsageRights.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.UsageRights.Commands.Update;

public class UpdateUsageRightCommand : IRequest<UpdatedUsageRightResponse>
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }

    public class UpdateUsageRightCommandHandler : IRequestHandler<UpdateUsageRightCommand, UpdatedUsageRightResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUsageRightRepository _usageRightRepository;
        private readonly UsageRightBusinessRules _usageRightBusinessRules;

        public UpdateUsageRightCommandHandler(IMapper mapper, IUsageRightRepository usageRightRepository,
                                         UsageRightBusinessRules usageRightBusinessRules)
        {
            _mapper = mapper;
            _usageRightRepository = usageRightRepository;
            _usageRightBusinessRules = usageRightBusinessRules;
        }

        public async Task<UpdatedUsageRightResponse> Handle(UpdateUsageRightCommand request, CancellationToken cancellationToken)
        {
            UsageRight? usageRight = await _usageRightRepository.GetAsync(predicate: ur => ur.Id == request.Id, cancellationToken: cancellationToken);
            await _usageRightBusinessRules.UsageRightShouldExistWhenSelected(usageRight);
            usageRight = _mapper.Map(request, usageRight);

            await _usageRightRepository.UpdateAsync(usageRight!, cancellationToken);

            UpdatedUsageRightResponse response = _mapper.Map<UpdatedUsageRightResponse>(usageRight);
            return response;
        }
    }
}