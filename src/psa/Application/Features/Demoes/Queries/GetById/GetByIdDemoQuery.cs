using Application.Features.Demoes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Demoes.Queries.GetById;

public class GetByIdDemoQuery : IRequest<GetByIdDemoResponse>
{
    public Guid Id { get; set; }

    public class GetByIdDemoQueryHandler : IRequestHandler<GetByIdDemoQuery, GetByIdDemoResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDemoRepository _demoRepository;
        private readonly DemoBusinessRules _demoBusinessRules;

        public GetByIdDemoQueryHandler(IMapper mapper, IDemoRepository demoRepository, DemoBusinessRules demoBusinessRules)
        {
            _mapper = mapper;
            _demoRepository = demoRepository;
            _demoBusinessRules = demoBusinessRules;
        }

        public async Task<GetByIdDemoResponse> Handle(GetByIdDemoQuery request, CancellationToken cancellationToken)
        {
            Demo? demo = await _demoRepository.GetAsync(predicate: d => d.Id == request.Id, cancellationToken: cancellationToken);
            await _demoBusinessRules.DemoShouldExistWhenSelected(demo);

            GetByIdDemoResponse response = _mapper.Map<GetByIdDemoResponse>(demo);
            return response;
        }
    }
}