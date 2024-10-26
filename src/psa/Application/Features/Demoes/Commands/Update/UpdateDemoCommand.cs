using Application.Features.Demoes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Demoes.Commands.Update;

public class UpdateDemoCommand : IRequest<UpdatedDemoResponse>
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Url { get; set; }
    public required Guid LanguageId { get; set; }
    public required Guid CategoryId { get; set; }
    public required Guid ArtistId { get; set; }

    public class UpdateDemoCommandHandler : IRequestHandler<UpdateDemoCommand, UpdatedDemoResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDemoRepository _demoRepository;
        private readonly DemoBusinessRules _demoBusinessRules;

        public UpdateDemoCommandHandler(IMapper mapper, IDemoRepository demoRepository,
                                         DemoBusinessRules demoBusinessRules)
        {
            _mapper = mapper;
            _demoRepository = demoRepository;
            _demoBusinessRules = demoBusinessRules;
        }

        public async Task<UpdatedDemoResponse> Handle(UpdateDemoCommand request, CancellationToken cancellationToken)
        {
            Demo? demo = await _demoRepository.GetAsync(predicate: d => d.Id == request.Id, cancellationToken: cancellationToken);
            await _demoBusinessRules.DemoShouldExistWhenSelected(demo);
            demo = _mapper.Map(request, demo);

            await _demoRepository.UpdateAsync(demo!);

            UpdatedDemoResponse response = _mapper.Map<UpdatedDemoResponse>(demo);
            return response;
        }
    }
}