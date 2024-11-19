using Application.Features.Demoes.Rules;
using Application.Services.Artists;
using Application.Services.FileHelperService;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.Demoes.Commands.Create;

public class CreateDemoCommand : IRequest<CreatedDemoResponse>
{
    public required string Name { get; set; }
    public required IFormFile File { get; set; }
    public required Guid LanguageId { get; set; }
    public required Guid ArtistId { get; set; }
    public required Guid CategoryId { get; set; }

    public class CreateDemoCommandHandler : IRequestHandler<CreateDemoCommand, CreatedDemoResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDemoRepository _demoRepository;
        private readonly IFileHelperService _fileHelperService;
        private readonly DemoBusinessRules _demoBusinessRules;

        public CreateDemoCommandHandler(IMapper mapper, IDemoRepository demoRepository,
                                         DemoBusinessRules demoBusinessRules, IFileHelperService fileHelperService)
        {
            _mapper = mapper;
            _demoRepository = demoRepository;
            _demoBusinessRules = demoBusinessRules;
            _fileHelperService = fileHelperService;
        }

        public async Task<CreatedDemoResponse> Handle(CreateDemoCommand request, CancellationToken cancellationToken)
        {
            Demo demo = _mapper.Map<Demo>(request);

            demo.Url = await _fileHelperService.UploadVoiceAsync(request.File, FileNames.DemoSpeech);

            await _demoRepository.AddAsync(demo, cancellationToken);

            CreatedDemoResponse response = _mapper.Map<CreatedDemoResponse>(demo);
            return response;
        }
    }
}