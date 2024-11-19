using Application.Features.Artists.Rules;
using Application.Features.RealVoiceProjects.Commands.Update;
using Application.Features.RealVoiceProjects.Rules;
using Application.Services.Artists;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;

namespace Application.Features.RealVoiceProjects.Commands.Reject;

public class RejectRealVoiceProjectCommand : IRequest<RejectedRealVoiceProjectResponse>
{
    public required Guid Id { get; set; }

    public class RejectRealVoiceProjectCommandHandler
     : IRequestHandler<RejectRealVoiceProjectCommand, RejectedRealVoiceProjectResponse>
    {
        private readonly IMapper _mapper;
        private readonly IArtistService _artistService;
        private readonly ArtistBusinessRules _artistBusinessRules;
        private readonly IRealVoiceProjectRepository _realVoiceProjectRepository;
        private readonly RealVoiceProjectBusinessRules _realVoiceProjectBusinessRules;

        public RejectRealVoiceProjectCommandHandler(
            IMapper mapper,
            IRealVoiceProjectRepository realVoiceProjectRepository,
            RealVoiceProjectBusinessRules realVoiceProjectBusinessRules,
            IArtistService artistService,
            ArtistBusinessRules artistBusinessRules)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _realVoiceProjectRepository = realVoiceProjectRepository ?? throw new ArgumentNullException(nameof(realVoiceProjectRepository));
            _realVoiceProjectBusinessRules = realVoiceProjectBusinessRules ?? throw new ArgumentNullException(nameof(realVoiceProjectBusinessRules));
            _artistService = artistService ?? throw new ArgumentNullException(nameof(artistService));
            _artistBusinessRules = artistBusinessRules ?? throw new ArgumentNullException(nameof(artistBusinessRules));
        }

        public async Task<RejectedRealVoiceProjectResponse> Handle(
            RejectRealVoiceProjectCommand request,
            CancellationToken cancellationToken)
        {
            var realVoiceProject = await getAndValidateProject(request.Id, cancellationToken);
            var artist = await getAndValidateArtist(realVoiceProject.ArtistId, cancellationToken);

            ValidateAndUpdateProjectStatus(realVoiceProject);

            realVoiceProject = await updateProject(request, realVoiceProject, cancellationToken);

            return _mapper.Map<RejectedRealVoiceProjectResponse>(realVoiceProject);
        }

        private async Task<RealVoiceProject> getAndValidateProject(
            Guid projectId,
            CancellationToken cancellationToken)
        {
            var project = await _realVoiceProjectRepository.GetAsync(
                predicate: rvp => rvp.Id == projectId,
                cancellationToken: cancellationToken);

            await _realVoiceProjectBusinessRules.RealVoiceProjectShouldExistWhenSelected(project);
            return project!;
        }

        private async Task<Artist> getAndValidateArtist(
            Guid artistId,
            CancellationToken cancellationToken)
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
                    project.SubmissionStatus = ProjectSubmissionStatus.Rejected;
                    break;

                case ProjectSubmissionStatus.Accepted:
                    throw new BusinessException("Accepted project must be sent for review before rejection.");

                case ProjectSubmissionStatus.RevisionsNeeded:
                    throw new BusinessException("Project requiring revisions must be sent for review before rejection.");
                //iade olacak demek ki.    
                //artist.SubmissionStatus = ProjectSubmissionStatus.Rejected;
                //break;

                case ProjectSubmissionStatus.Finalized:
                    throw new BusinessException("Finalized project status cannot be modified.");

                case ProjectSubmissionStatus.Rejected:
                    throw new BusinessException("Project is already rejected.");

                default:
                    throw new BusinessException($"Invalid project status: {project.SubmissionStatus}");
            }
        }

        private async Task<RealVoiceProject> updateProject(
            RejectRealVoiceProjectCommand request,
            RealVoiceProject realVoiceProject,
            CancellationToken cancellationToken)
        {
            realVoiceProject = _mapper.Map(request, realVoiceProject);
            await _realVoiceProjectRepository.UpdateAsync(realVoiceProject, cancellationToken);
            return realVoiceProject;
        }
    }
}