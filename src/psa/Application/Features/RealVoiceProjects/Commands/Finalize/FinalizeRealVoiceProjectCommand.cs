using Application.Features.Artists.Rules;
using Application.Features.RealVoiceProjects.Rules;
using Application.Services.Artists;
using Application.Services.FileHelperService;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;

namespace Application.Features.RealVoiceProjects.Commands.Finalize;

public class FinalizeRealVoiceProjectCommand : IRequest<FinalizedRealVoiceProjectResponse>
{
    public required Guid Id { get; set; }

    public required IFormFile File { get; set; }

    public class FinalizeRealVoiceProjectCommandHandler
    : IRequestHandler<FinalizeRealVoiceProjectCommand, FinalizedRealVoiceProjectResponse>
    {
        private readonly IMapper _mapper;
        private readonly IArtistService _artistService;
        private readonly ArtistBusinessRules _artistBusinessRules;
        private readonly IFileHelperService _fileHelperService;
        private readonly IRealVoiceProjectRepository _realVoiceProjectRepository;
        private readonly RealVoiceProjectBusinessRules _realVoiceProjectBusinessRules;

        public FinalizeRealVoiceProjectCommandHandler(
            IMapper mapper,
            IRealVoiceProjectRepository realVoiceProjectRepository,
            RealVoiceProjectBusinessRules realVoiceProjectBusinessRules,
            IArtistService artistService,
            ArtistBusinessRules artistBusinessRules,
            IFileHelperService fileHelperService)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _realVoiceProjectRepository = realVoiceProjectRepository ?? throw new ArgumentNullException(nameof(realVoiceProjectRepository));
            _realVoiceProjectBusinessRules = realVoiceProjectBusinessRules ?? throw new ArgumentNullException(nameof(realVoiceProjectBusinessRules));
            _artistService = artistService ?? throw new ArgumentNullException(nameof(artistService));
            _artistBusinessRules = artistBusinessRules ?? throw new ArgumentNullException(nameof(artistBusinessRules));
            _fileHelperService = fileHelperService ?? throw new ArgumentNullException(nameof(fileHelperService));
        }

        public async Task<FinalizedRealVoiceProjectResponse> Handle(
            FinalizeRealVoiceProjectCommand request,
            CancellationToken cancellationToken)
        {

            // Get and validate project and artist
            var realVoiceProject = await getAndValidateProject(request.Id, cancellationToken);
            var artist = await getAndValidateArtist(realVoiceProject.ArtistId, cancellationToken);

            // Validate and update status
            ValidateAndUpdateProjectStatus(realVoiceProject);

            // Update project with new data
            realVoiceProject = await updateProject(request, realVoiceProject, cancellationToken);

            return _mapper.Map<FinalizedRealVoiceProjectResponse>(realVoiceProject);
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
                    throw new BusinessException("Project under review cannot be finalized.");

                case ProjectSubmissionStatus.Accepted:
                    project.SubmissionStatus = ProjectSubmissionStatus.Finalized;
                    break;

                case ProjectSubmissionStatus.RevisionsNeeded:
                    throw new BusinessException("Project requiring revisions must be reviewed first.");

                case ProjectSubmissionStatus.Finalized:
                    throw new BusinessException("Project is already finalized.");

                case ProjectSubmissionStatus.Rejected:
                    throw new BusinessException("Rejected project cannot be finalized.");

                default:
                    throw new BusinessException($"Invalid project status: {project.SubmissionStatus}");
            }
        }

        private async Task<RealVoiceProject> updateProject(
            FinalizeRealVoiceProjectCommand request,
            RealVoiceProject realVoiceProject,
            CancellationToken cancellationToken)
        {
            // Upload voice file
            var url = await _fileHelperService.UploadVoiceAsync(request.File, FileNames.RealSpeechOutput);

            // Update project with new data
            realVoiceProject = _mapper.Map(request, realVoiceProject);
            realVoiceProject.Url = url;

            await _realVoiceProjectRepository.UpdateAsync(realVoiceProject, cancellationToken);

            return realVoiceProject;
        }
    }
}