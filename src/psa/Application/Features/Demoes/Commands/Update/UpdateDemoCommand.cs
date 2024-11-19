using Application.Features.Demoes.Rules;
using Application.Services.Artists;
using Application.Services.FileHelperService;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.Demoes.Commands.Update;

public class UpdateDemoCommand : IRequest<UpdatedDemoResponse>
{
    public required Guid Id { get; set; }
    public string? Name { get; set; }
    public IFormFile? File { get; set; }
    public Guid? LanguageId { get; set; }
    public Guid? CategoryId { get; set; }
    public Guid? ArtistId { get; set; }

    public class UpdateDemoCommandHandler : IRequestHandler<UpdateDemoCommand, UpdatedDemoResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDemoRepository _demoRepository;
        private readonly IFileHelperService _fileHelperService;
        private readonly DemoBusinessRules _demoBusinessRules;

        public UpdateDemoCommandHandler(IMapper mapper, IDemoRepository demoRepository,
                                         DemoBusinessRules demoBusinessRules, IFileHelperService fileHelperService)
        {
            _mapper = mapper;
            _demoRepository = demoRepository;
            _demoBusinessRules = demoBusinessRules;
            _fileHelperService = fileHelperService;
        }

        public async Task<UpdatedDemoResponse> Handle(UpdateDemoCommand request, CancellationToken cancellationToken)
        {
            Demo? demo = await _demoRepository.GetAsync(predicate: d => d.Id == request.Id, cancellationToken: cancellationToken);
            await _demoBusinessRules.DemoShouldExistWhenSelected(demo);
            demo = _mapper.Map(request, demo);

            if(request.File != null)
                demo!.Url = await _fileHelperService.UploadVoiceAsync(request.File, FileNames.DemoSpeech);


            UpdatedDemoResponse response = _mapper.Map<UpdatedDemoResponse>(demo);
            return response;
        }
    }
}