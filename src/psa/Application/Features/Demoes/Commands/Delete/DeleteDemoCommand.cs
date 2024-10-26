using Application.Features.Demoes.Constants;
using Application.Features.Demoes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Demoes.Commands.Delete;

public class DeleteDemoCommand : IRequest<DeletedDemoResponse>
{
    public Guid Id { get; set; }

    public class DeleteDemoCommandHandler : IRequestHandler<DeleteDemoCommand, DeletedDemoResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDemoRepository _demoRepository;
        private readonly DemoBusinessRules _demoBusinessRules;

        public DeleteDemoCommandHandler(IMapper mapper, IDemoRepository demoRepository,
                                         DemoBusinessRules demoBusinessRules)
        {
            _mapper = mapper;
            _demoRepository = demoRepository;
            _demoBusinessRules = demoBusinessRules;
        }

        public async Task<DeletedDemoResponse> Handle(DeleteDemoCommand request, CancellationToken cancellationToken)
        {
            Demo? demo = await _demoRepository.GetAsync(predicate: d => d.Id == request.Id, cancellationToken: cancellationToken);
            await _demoBusinessRules.DemoShouldExistWhenSelected(demo);

            await _demoRepository.DeleteAsync(demo!);

            DeletedDemoResponse response = _mapper.Map<DeletedDemoResponse>(demo);
            return response;
        }
    }
}