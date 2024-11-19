using Application.Features.Artists.Rules;
using Application.Features.RealVoiceProjects.Rules;
using Application.Services.Artists;
using Application.Services.FileHelperService;
using Application.Services.MailService;
using Application.Services.MailTemplateService;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using MimeKit;
using Org.BouncyCastle.Asn1.Ocsp;

namespace Application.Features.RealVoiceProjects.Commands.Create;

public class CreateRealVoiceProjectCommand : IRequest<CreatedRealVoiceProjectResponse>
{
    public required string Name { get; set; }
    public required string Text { get; set; }
    public required Guid ArtistId { get; set; }
    public required Guid LanguageId { get; set; }
    public required Guid UsageRightId { get; set; }
    public Guid? DemoId { get; set; }
    public string? Description { get; set; }
    public ICollection<IFormFile>? Files { get; set; } //burada url deðil direkt file al. sonra amazon s3'e yükle dosyayý.

    public class CreateRealVoiceProjectCommandHandler : IRequestHandler<CreateRealVoiceProjectCommand, CreatedRealVoiceProjectResponse>
    {
        private readonly IMapper _mapper;
        private readonly IArtistService _artistService;
        private readonly ArtistBusinessRules _artistBusinessRules;
        private readonly IRealVoiceProjectRepository _realVoiceProjectRepository;
        private readonly RealVoiceProjectBusinessRules _realVoiceProjectBusinessRules;
        private readonly IEmailTemplateService _emailTemplateService;
        private readonly IEMailService _mailService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IFileHelperService _fileHelperService;
        public CreateRealVoiceProjectCommandHandler(IMapper mapper, IRealVoiceProjectRepository realVoiceProjectRepository,
                                         RealVoiceProjectBusinessRules realVoiceProjectBusinessRules, IArtistService artistService, ArtistBusinessRules artistBusinessRules, IEmailTemplateService emailTemplateService, IEMailService mailService, IHttpContextAccessor httpContextAccessor, IFileHelperService fileHelperService)
        {
            _mapper = mapper;
            _realVoiceProjectRepository = realVoiceProjectRepository;
            _realVoiceProjectBusinessRules = realVoiceProjectBusinessRules;
            _artistService = artistService;
            _artistBusinessRules = artistBusinessRules;
            _emailTemplateService = emailTemplateService;
            _mailService = mailService;
            _httpContextAccessor = httpContextAccessor;
            _fileHelperService = fileHelperService;
        }

        public async Task<CreatedRealVoiceProjectResponse> Handle(CreateRealVoiceProjectCommand request, CancellationToken cancellationToken)
        {
            RealVoiceProject realVoiceProject = _mapper.Map<RealVoiceProject>(request);

            var artist = await _artistService.GetAsync(a => a.Id == realVoiceProject.ArtistId, cancellationToken: cancellationToken);
            await _artistBusinessRules.ArtistShouldExistWhenSelected(artist);

            if (request.Files != null)
                foreach (var file in request.Files)
                {
                    var url = await _fileHelperService.UploadDocumentAsync(file, FileNames.ProjectDocument);
                    realVoiceProject!.FileUrls!.Add(url);
                }


            await _realVoiceProjectRepository.AddAsync(realVoiceProject, cancellationToken);

            if (!string.IsNullOrEmpty(artist!.MailAddress))
            {
                var requestContext = _httpContextAccessor.HttpContext?.Request;
                if (requestContext == null)
                    throw new Exception("Request yok!");

                var baseUrl = $"{requestContext.Scheme}://{requestContext.Host}";

                var toEmailList = new List<MailboxAddress> { new(name: artist.MailAddress, artist.MailAddress) };
                var projectUrl = $"{baseUrl}{requestContext.Path}/{realVoiceProject.Id}"; 
                var mail = _emailTemplateService.GetNewProjectNotificationEmail(toEmailList, realVoiceProject.Name, projectUrl);

                await _mailService.SendEmailAsync(mail);
            }

            CreatedRealVoiceProjectResponse response = _mapper.Map<CreatedRealVoiceProjectResponse>(realVoiceProject);
            return response;
        }

    }
}