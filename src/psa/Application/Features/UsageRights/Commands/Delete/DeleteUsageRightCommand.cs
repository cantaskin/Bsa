using Application.Features.UsageRights.Constants;
using Application.Features.UsageRights.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.UsageRights.Commands.Delete;

public class DeleteUsageRightCommand : IRequest<DeletedUsageRightResponse>
{
    public Guid Id { get; set; }

    public class DeleteUsageRightCommandHandler : IRequestHandler<DeleteUsageRightCommand, DeletedUsageRightResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUsageRightRepository _usageRightRepository;
        private readonly UsageRightBusinessRules _usageRightBusinessRules;

        public DeleteUsageRightCommandHandler(IMapper mapper, IUsageRightRepository usageRightRepository,
                                         UsageRightBusinessRules usageRightBusinessRules)
        {
            _mapper = mapper;
            _usageRightRepository = usageRightRepository;
            _usageRightBusinessRules = usageRightBusinessRules;
        }

        public async Task<DeletedUsageRightResponse> Handle(DeleteUsageRightCommand request, CancellationToken cancellationToken)
        {
            UsageRight? usageRight = await _usageRightRepository.GetAsync(predicate: ur => ur.Id == request.Id, cancellationToken: cancellationToken);
            await _usageRightBusinessRules.UsageRightShouldExistWhenSelected(usageRight);

            await _usageRightRepository.DeleteAsync(usageRight!);

            DeletedUsageRightResponse response = _mapper.Map<DeletedUsageRightResponse>(usageRight);
            return response;
        }
    }
}