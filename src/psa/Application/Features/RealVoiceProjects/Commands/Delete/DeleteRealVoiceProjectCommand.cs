using Application.Features.RealVoiceProjects.Constants;
using Application.Features.RealVoiceProjects.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.RealVoiceProjects.Commands.Delete;

public class DeleteRealVoiceProjectCommand : IRequest<DeletedRealVoiceProjectResponse>
{
    public Guid Id { get; set; }

    public class DeleteRealVoiceProjectCommandHandler : IRequestHandler<DeleteRealVoiceProjectCommand, DeletedRealVoiceProjectResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRealVoiceProjectRepository _realVoiceProjectRepository;
        private readonly RealVoiceProjectBusinessRules _realVoiceProjectBusinessRules;

        public DeleteRealVoiceProjectCommandHandler(IMapper mapper, IRealVoiceProjectRepository realVoiceProjectRepository,
                                         RealVoiceProjectBusinessRules realVoiceProjectBusinessRules)
        {
            _mapper = mapper;
            _realVoiceProjectRepository = realVoiceProjectRepository;
            _realVoiceProjectBusinessRules = realVoiceProjectBusinessRules;
        }

        public async Task<DeletedRealVoiceProjectResponse> Handle(DeleteRealVoiceProjectCommand request, CancellationToken cancellationToken)
        {
            RealVoiceProject? realVoiceProject = await _realVoiceProjectRepository.GetAsync(predicate: rvp => rvp.Id == request.Id, cancellationToken: cancellationToken);
            await _realVoiceProjectBusinessRules.RealVoiceProjectShouldExistWhenSelected(realVoiceProject);

            await _realVoiceProjectRepository.DeleteAsync(realVoiceProject!);

            DeletedRealVoiceProjectResponse response = _mapper.Map<DeletedRealVoiceProjectResponse>(realVoiceProject);
            return response;
        }
    }
}