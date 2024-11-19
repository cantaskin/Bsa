using Application.Features.AiVoiceProjects.Constants;
using Application.Features.AiVoiceProjects.Rules;
using Application.Features.Artists.Rules;
using Application.Features.Languages.Rules;
using Application.Services.Artists;
using Application.Services.Languages;
using Application.Services.MailService;
using Application.Services.MailTemplateService;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Domain.Enums;
using Application.Services.SpeechsService;
using MimeKit;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Mailing;
using NArchitecture.Core.Security.Entities;

namespace Application.Features.AiVoiceProjects.Commands.Create;

public class CreateAiVoiceProjectCommand : IRequest<CreatedAiVoiceProjectResponse>
{
    public required string Name { get; set; }
    public required string Text { get; set; }
    public required Guid ArtistId { get; set; }
    public required Guid LanguageId { get; set; }
    public required Guid UsageRightId { get; set; }
    public required ProjectSelectionEnum ProjectSelection { get; set; }
    public Guid? DemoId { get; set; }
    public class CreateAiVoiceProjectCommandHandler : IRequestHandler<CreateAiVoiceProjectCommand, CreatedAiVoiceProjectResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAiVoiceProjectRepository _aiVoiceProjectRepository;
        private readonly ILanguageService _languageService;
        private readonly IArtistService _artistService;
        private readonly ISpeechService _speechService;
        private readonly AiVoiceProjectBusinessRules _aiVoiceProjectBusinessRules;
        private readonly IEMailService _emailService;
        private readonly IEmailTemplateService _emailTemplateService;

        public CreateAiVoiceProjectCommandHandler(IMapper mapper, IAiVoiceProjectRepository aiVoiceProjectRepository,
                                         AiVoiceProjectBusinessRules aiVoiceProjectBusinessRules, ILanguageService languageService, 
                                         ISpeechService speechService, IArtistService artistService, IEMailService emailService, IEmailTemplateService emailTemplateService)
        {
            _mapper = mapper;
            _aiVoiceProjectRepository = aiVoiceProjectRepository;
            _aiVoiceProjectBusinessRules = aiVoiceProjectBusinessRules;
            _languageService = languageService;
            _speechService = speechService;
            _artistService = artistService;
            _emailService = emailService;
            _emailTemplateService = emailTemplateService;
        }

        public async Task<CreatedAiVoiceProjectResponse> Handle(CreateAiVoiceProjectCommand request, CancellationToken cancellationToken)
        {
            AiVoiceProject aiVoiceProject = _mapper.Map<AiVoiceProject>(request);
;
            var artist = await validateAndGetArtistAsync(request.ArtistId);
            var language = await validateAndGetLanguageAsync(request.LanguageId);

            string voiceId = GetVoiceIdBySelection(selection: request.ProjectSelection, artist);
            var url = await _speechService.TextToSpeechAsync(request.Text, voiceId, language.LanguageCode);

            await _aiVoiceProjectRepository.AddAsync(aiVoiceProject, cancellationToken);
            aiVoiceProject.Url = url;

            await _aiVoiceProjectRepository.UpdateAsync(aiVoiceProject, cancellationToken);
            
            var toEmailList = new List<MailboxAddress> { new(name: artist.MailAddress, artist.MailAddress) };
            var mail = _emailTemplateService.GetNewAiProjectNotificationEmail(toEmailList);
            await _emailService.SendEmailAsync(mail);

            //birol abiye de mail atýlacak. Ödeme iþleminden sonra tabi bu da çok önemli. Ýkisi de ödeme iþleminden sonra olacak iyzico entegre edince düzenlicem.

            CreatedAiVoiceProjectResponse response = _mapper.Map<CreatedAiVoiceProjectResponse>(aiVoiceProject);
            return response;
        }

        private async Task<Artist> validateAndGetArtistAsync(Guid artistId)
        {
            var artist = await _artistService.GetAsync(a => a.Id == artistId);
            await _artistService.ArtistShouldExistWhenSelected(artist);
            return artist;
        }
        private async Task<Language> validateAndGetLanguageAsync(Guid languageIdId)
        {
            var language = await _languageService.GetAsync(a => a.Id == languageIdId);
            await _languageService.LanguageShouldExistWhenSelected(language);
            return language;
        }
        private string GetVoiceIdBySelection(ProjectSelectionEnum selection, Artist artist)
        {
                string voiceId = selection switch
                {
                    ProjectSelectionEnum.InstantCloneVoice => string.IsNullOrEmpty(artist.InstVoiceId)
                        ? throw new BusinessException(AiVoiceProjectsBusinessMessages.VoiceIdNotFound)
                        : artist.InstVoiceId,

                    ProjectSelectionEnum.ProfessionalCloneVoice => string.IsNullOrEmpty(artist.ProfVoiceId)
                        ? throw new BusinessException(AiVoiceProjectsBusinessMessages.VoiceIdNotFound)
                        : artist.ProfVoiceId,

                    _ => throw new BusinessException(AiVoiceProjectsBusinessMessages.InvalidProjectSelection)
                };

                return voiceId;
        }
    }
    

}