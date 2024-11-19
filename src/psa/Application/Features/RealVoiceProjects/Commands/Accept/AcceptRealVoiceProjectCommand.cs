using Application.Features.Artists.Rules;
using Application.Features.RealVoiceProjects.Rules;
using Application.Services.Artists;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;

namespace Application.Features.RealVoiceProjects.Commands.Accept;

public class AcceptRealVoiceProjectCommand : IRequest<AcceptedRealVoiceProjectResponse>
{
    public required Guid Id { get; set; }

    public class AcceptRealVoiceProjectCommandHandler : IRequestHandler<AcceptRealVoiceProjectCommand, AcceptedRealVoiceProjectResponse>
    {
        private readonly IMapper _mapper;
        private readonly IArtistService _artistService;
        private readonly ArtistBusinessRules _artistBusinessRules;
        private readonly IRealVoiceProjectRepository _realVoiceProjectRepository;
        private readonly RealVoiceProjectBusinessRules _realVoiceProjectBusinessRules;

        public AcceptRealVoiceProjectCommandHandler(IMapper mapper, IRealVoiceProjectRepository realVoiceProjectRepository,
                                         RealVoiceProjectBusinessRules realVoiceProjectBusinessRules, IArtistService artistService, ArtistBusinessRules businessRules)
        {
            _mapper = mapper;
            _realVoiceProjectRepository = realVoiceProjectRepository;
            _realVoiceProjectBusinessRules = realVoiceProjectBusinessRules;
            _artistService = artistService;
            _artistBusinessRules = businessRules;
        }

        //Revize için bu fonksiyon kullanýlacak. Veya Proje draft halindeyken belki deðiþim yapýlabilir.

        public async Task<AcceptedRealVoiceProjectResponse> Handle(
       AcceptRealVoiceProjectCommand request,
       CancellationToken cancellationToken)
        {
            var realVoiceProject = await getAndValidateProject(request.Id, cancellationToken);
            var artist = await getAndValidateArtist(realVoiceProject.ArtistId, cancellationToken);

            ValidateAndUpdateProjectStatus(realVoiceProject);

            realVoiceProject = _mapper.Map(request, realVoiceProject);
            await _realVoiceProjectRepository.UpdateAsync(realVoiceProject, cancellationToken);

            return _mapper.Map<AcceptedRealVoiceProjectResponse>(realVoiceProject);
        }

        private async Task<RealVoiceProject> getAndValidateProject(Guid projectId, CancellationToken cancellationToken)
        {
            var project = await _realVoiceProjectRepository.GetAsync(
                predicate: rvp => rvp.Id == projectId,
                cancellationToken: cancellationToken);

            await _realVoiceProjectBusinessRules.RealVoiceProjectShouldExistWhenSelected(project);
            return project!;
        }

        private async Task<Artist> getAndValidateArtist(Guid artistId, CancellationToken cancellationToken)
        {
            var artist = await _artistService.GetAsync(a => a.Id == artistId, cancellationToken: cancellationToken);
            await _artistBusinessRules.ArtistShouldExistWhenSelected(artist);
            return artist!;
        }

        private static void ValidateAndUpdateProjectStatus(RealVoiceProject project)
        {
            switch (project.SubmissionStatus)
            {
                case ProjectSubmissionStatus.UnderReview:
                    project.SubmissionStatus = ProjectSubmissionStatus.Accepted;
                    break;

                case ProjectSubmissionStatus.Accepted:
                    throw new BusinessException("Project is already accepted.");

                case ProjectSubmissionStatus.RevisionsNeeded:
                    throw new BusinessException("Project requiring revisions must be sent for review first.");
                    //artist.SubmissionStatus = ProjectSubmissionStatus.Accepted;
                    //Burada review sayýsý azalacak.

                case ProjectSubmissionStatus.Finalized:
                    throw new BusinessException("Finalized project status cannot be modified.");

                case ProjectSubmissionStatus.Rejected:
                    throw new BusinessException("Rejected project status cannot be modified.");

                default:
                    throw new BusinessException($"Invalid status: {project.SubmissionStatus}");
            }
        }
    }
}