using Application.Features.Artists.Rules;
using Application.Features.RealVoiceProjects.Rules;
using Application.Services.Artists;
using Application.Services.FileHelperService;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.RealVoiceProjects.Commands.Update;

public class UpdateRealVoiceProjectCommand : IRequest<UpdatedRealVoiceProjectResponse>
{
    public required Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Text { get; set; }
    public Guid? ArtistId { get; set; }
    public Guid? LanguageId { get; set; }
    public Guid? UsageRightId { get; set; }

    public IFormFile? File { get; set; }
    public ICollection<IFormFile>? FileUrls { get; set; } //burada url deðil direkt file al. sonra amazon s3'e yükle dosyayý.
    public Guid? DemoId { get; set; }
    public string? Description { get; set; }

    public class UpdateRealVoiceProjectCommandHandler : IRequestHandler<UpdateRealVoiceProjectCommand, UpdatedRealVoiceProjectResponse>
    {
        private readonly IMapper _mapper;
        private readonly IArtistService _artistService;
        private readonly ArtistBusinessRules _artistBusinessRules;
        private readonly IRealVoiceProjectRepository _realVoiceProjectRepository;
        private readonly RealVoiceProjectBusinessRules _realVoiceProjectBusinessRules;
        private readonly IFileHelperService _fileHelperService;
        public UpdateRealVoiceProjectCommandHandler(IMapper mapper, IRealVoiceProjectRepository realVoiceProjectRepository,
                                         RealVoiceProjectBusinessRules realVoiceProjectBusinessRules, IArtistService artistService, ArtistBusinessRules businessRules, IFileHelperService fileHelperService)
        {
            _mapper = mapper;
            _realVoiceProjectRepository = realVoiceProjectRepository;
            _realVoiceProjectBusinessRules = realVoiceProjectBusinessRules;
            _artistService = artistService;
            _artistBusinessRules = businessRules;
            _fileHelperService = fileHelperService;
        }

        //Revize için bu fonksiyon kullanýlacak. Veya Proje draft halindeyken belki deðiþim yapýlabilir.

        public async Task<UpdatedRealVoiceProjectResponse> Handle(UpdateRealVoiceProjectCommand request, CancellationToken cancellationToken)
        {
            RealVoiceProject? realVoiceProject = await _realVoiceProjectRepository.GetAsync(predicate: rvp => rvp.Id == request.Id, cancellationToken: cancellationToken);
            await _realVoiceProjectBusinessRules.RealVoiceProjectShouldExistWhenSelected(realVoiceProject);
            realVoiceProject = _mapper.Map(request, realVoiceProject);

            if (request.FileUrls != null)
                foreach (var file in request.FileUrls)
                {
                   var url = await _fileHelperService.UploadDocumentAsync(file, FileNames.ProjectDocument);
                   realVoiceProject!.FileUrls!.Add(url);
                }

            if (request.File != null) 
                realVoiceProject!.Url = await _fileHelperService.UploadVoiceAsync(request.File, FileNames.RealSpeechOutput);

            var artist = await _artistService.GetAsync(a => a.Id == realVoiceProject!.ArtistId, cancellationToken: cancellationToken);
            await _artistBusinessRules.ArtistShouldExistWhenSelected(artist);
            
            await _realVoiceProjectRepository.UpdateAsync(realVoiceProject!, cancellationToken);

            UpdatedRealVoiceProjectResponse response = _mapper.Map<UpdatedRealVoiceProjectResponse>(realVoiceProject);
            return response;
        }
    }
}