using Application.Features.Artists.Rules;
using Application.Features.RealVoiceProjects.Commands.Update;
using Application.Features.RealVoiceProjects.Rules;
using Application.Services.Artists;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.RealVoiceProjects.Commands.RevisionNeed;

public class RevisionNeedRealVoiceProjectCommand : IRequest<RevisionNeededRealVoiceProjectResponse>
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Text { get; set; }
    public required Guid ArtistId { get; set; }
    public required Guid LanguageId { get; set; }
    public required Guid UsageRightId { get; set; }
    public ICollection<string>? FileUrls { get; set; } //burada url deðil direkt file al. sonra amazon s3'e yükle dosyayý.
    public Guid? DemoId { get; set; }
    public string? Description { get; set; }
    public required string RevisionDescription { get; set; } 

    public class RevisionNeedRealVoiceProjectCommandHandler : IRequestHandler<RevisionNeedRealVoiceProjectCommand, RevisionNeededRealVoiceProjectResponse>
    {
        private readonly IMapper _mapper;
        private readonly IArtistService _artistService;
        private readonly ArtistBusinessRules _artistBusinessRules;
        private readonly IRealVoiceProjectRepository _realVoiceProjectRepository;
        private readonly RealVoiceProjectBusinessRules _realVoiceProjectBusinessRules;

        public RevisionNeedRealVoiceProjectCommandHandler(IMapper mapper, IRealVoiceProjectRepository realVoiceProjectRepository,
                                         RealVoiceProjectBusinessRules realVoiceProjectBusinessRules, IArtistService artistService, ArtistBusinessRules businessRules)
        {
            _mapper = mapper;
            _realVoiceProjectRepository = realVoiceProjectRepository;
            _realVoiceProjectBusinessRules = realVoiceProjectBusinessRules;
            _artistService = artistService;
            _artistBusinessRules = businessRules;
        }

        //Revize için bu fonksiyon kullanýlacak. Veya Proje draft halindeyken belki deðiþim yapýlabilir.

        public async Task<RevisionNeededRealVoiceProjectResponse> Handle(RevisionNeedRealVoiceProjectCommand request, CancellationToken cancellationToken)
        {
            RealVoiceProject? realVoiceProject = await _realVoiceProjectRepository.GetAsync(predicate: rvp => rvp.Id == request.Id, cancellationToken: cancellationToken);
            await _realVoiceProjectBusinessRules.RealVoiceProjectShouldExistWhenSelected(realVoiceProject);
            realVoiceProject = _mapper.Map(request, realVoiceProject);

            var artist = await _artistService.GetAsync(a => a.Id == realVoiceProject!.ArtistId, cancellationToken: cancellationToken);
            await _artistBusinessRules.ArtistShouldExistWhenSelected(artist);
            
            await _realVoiceProjectRepository.UpdateAsync(realVoiceProject!, cancellationToken);

            RevisionNeededRealVoiceProjectResponse response = _mapper.Map<RevisionNeededRealVoiceProjectResponse>(realVoiceProject);
            return response;
        }
    }
}