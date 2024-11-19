using Application.Features.RealVoiceProjects.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.RealVoiceProjects.Queries.GetById;

public class GetByIdRealVoiceProjectQuery : IRequest<GetByIdRealVoiceProjectResponse>
{
    public Guid Id { get; set; }

    public class GetByIdRealVoiceProjectQueryHandler : IRequestHandler<GetByIdRealVoiceProjectQuery, GetByIdRealVoiceProjectResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRealVoiceProjectRepository _realVoiceProjectRepository;
        private readonly RealVoiceProjectBusinessRules _realVoiceProjectBusinessRules;

        public GetByIdRealVoiceProjectQueryHandler(IMapper mapper, IRealVoiceProjectRepository realVoiceProjectRepository, RealVoiceProjectBusinessRules realVoiceProjectBusinessRules)
        {
            _mapper = mapper;
            _realVoiceProjectRepository = realVoiceProjectRepository;
            _realVoiceProjectBusinessRules = realVoiceProjectBusinessRules;
        }

        public async Task<GetByIdRealVoiceProjectResponse> Handle(GetByIdRealVoiceProjectQuery request, CancellationToken cancellationToken)
        {
            RealVoiceProject? realVoiceProject = await _realVoiceProjectRepository.GetAsync(predicate: rvp => rvp.Id == request.Id, cancellationToken: cancellationToken);
            await _realVoiceProjectBusinessRules.RealVoiceProjectShouldExistWhenSelected(realVoiceProject);

            GetByIdRealVoiceProjectResponse response = _mapper.Map<GetByIdRealVoiceProjectResponse>(realVoiceProject);
            return response;
        }
    }
}