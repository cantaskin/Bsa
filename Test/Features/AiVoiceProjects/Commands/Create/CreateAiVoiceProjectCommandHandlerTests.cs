using Moq;
using Xunit;
using FluentAssertions;
using Application.Features.AiVoiceProjects.Commands.Create;
using Application.Services.Repositories;
using Application.Services.Artists;
using Application.Services.Languages;
using Application.Services.MailService;
using Application.Services.MailTemplateService;
using Application.Services.SpeechsService;
using Application.Features.AiVoiceProjects.Rules;
using Application.Features.Artists.Rules;
using Application.Features.Languages.Rules;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using System;
using System.Threading;
using System.Threading.Tasks;
using static Application.Features.AiVoiceProjects.Commands.Create.CreateAiVoiceProjectCommand;
using MimeKit;
using Shouldly;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using System.Linq.Expressions;

public class CreateAiVoiceProjectCommandHandlerTests
{
    private readonly Mock<IMapper> _mapperMock = new Mock<IMapper>();
    private readonly Mock<IAiVoiceProjectRepository> _repositoryMock = new Mock<IAiVoiceProjectRepository>();
    private readonly Mock<ILanguageService> _languageServiceMock = new Mock<ILanguageService>();
    private readonly Mock<IArtistService> _artistServiceMock = new Mock<IArtistService>();
    private readonly Mock<ISpeechService> _speechServiceMock = new Mock<ISpeechService>();
    private readonly Mock<IEMailService> _emailServiceMock = new Mock<IEMailService>();
    private readonly Mock<ILocalizationService> _localizationServiceMock = new Mock<ILocalizationService>();
    private readonly Mock<IEmailTemplateService> _emailTemplateServiceMock = new Mock<IEmailTemplateService>();
    private readonly AiVoiceProjectBusinessRules _aiVoiceProjectBusinessRules;

    private readonly CreateAiVoiceProjectCommandHandler _handler;

    public CreateAiVoiceProjectCommandHandlerTests()
    {
        _aiVoiceProjectBusinessRules = new AiVoiceProjectBusinessRules(_repositoryMock.Object, _localizationServiceMock.Object);
        _handler = new CreateAiVoiceProjectCommandHandler(
            _mapperMock.Object, _repositoryMock.Object, _aiVoiceProjectBusinessRules,
            _languageServiceMock.Object, _speechServiceMock.Object, _artistServiceMock.Object,
           _emailServiceMock.Object, _emailTemplateServiceMock.Object);
    }


    //[Fact]
    //public async Task Handle_ShouldCreateProjectSuccessfully_WhenRequestIsValid()
    //{
    //    // Arrange
    //    var command = new CreateAiVoiceProjectCommand
    //    {
    //        Name = "Test Project",
    //        Text = "Sample Text",
    //        ArtistId = Guid.NewGuid(),
    //        LanguageId = Guid.NewGuid(),
    //        UsageRightId = Guid.NewGuid(),
    //        ProjectSelection = ProjectSelectionEnum.InstantCloneVoice
    //    };

    //    var artist = new Artist { Id = command.ArtistId, InstVoiceId = "inst-voice-id", MailAddress = "artist@example.com" };
    //    var language = new Language { Id = command.LanguageId, LanguageCode = "en" };
    //    var aiVoiceProject = new AiVoiceProject { Id = Guid.NewGuid(), Name = command.Name, Url = "http://audio.com/sample.mp3" };

    //    _artistServiceMock.Setup(a => a.GetAsync(It.IsAny<Func<Artist, bool>>())).ReturnsAsync(artist);
    //    _languageServiceMock.Setup(l => l.GetAsync(It.IsAny<Func<Language, bool>>())).ReturnsAsync(language);
    //    _speechServiceMock.Setup(s => s.TextToSpeechAsync(command.Text, artist.InstVoiceId, language.LanguageCode)).ReturnsAsync(aiVoiceProject.Url);
    //    _mapperMock.Setup(m => m.Map<AiVoiceProject>(command)).Returns(aiVoiceProject);
    //    _repositoryMock.Setup(r => r.AddAsync(It.IsAny<AiVoiceProject>(), It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);

    //    // Act
    //    var result = await _handler.Handle(command, CancellationToken.None);

    //    // Assert
    //    result.Url.Should().Be(aiVoiceProject.Url);
    //    _repositoryMock.Verify(r => r.AddAsync(It.Is<AiVoiceProject>(p => p.Name == command.Name), It.IsAny<CancellationToken>()), Times.Once);
    //    _emailServiceMock.Verify(e => e.SendEmailAsync(It.IsAny<MimeMessage>()), Times.Once);
    //}

    //[Fact]
    //public async Task Handle_ShouldThrowException_WhenLanguageNotFound()
    //{
    //    // Arrange
    //    var command = new CreateAiVoiceProjectCommand { LanguageId = Guid.NewGuid() };
    //    _languageServiceMock.Setup(l => l.GetAsync(It.IsAny<Func<Language, bool>>())).ReturnsAsync((Language)null);

    //    // Act
    //    Func<Task> act = async () => await _handler.Handle(command, CancellationToken.None);

    //    // Assert
    //    await act.Should().ThrowAsync<BusinessException>().WithMessage("Language not found.");
    //}

    //[Fact]
    //public async Task Handle_ShouldThrowException_WhenVoiceIdNotAvailable()
    //{
    //    // Arrange
    //    var command = new CreateAiVoiceProjectCommand
    //    {
    //        ProjectSelection = ProjectSelectionEnum.InstantCloneVoice,
    //        ArtistId = Guid.NewGuid()
    //    };
    //    var artist = new Artist { InstVoiceId = null };
    //    _artistServiceMock.Setup(a => a.GetAsync(It.IsAny<Func<Artist, bool>>())).ReturnsAsync(artist);

    //    // Act
    //    Func<Task> act = async () => await _handler.Handle(command, CancellationToken.None);

    //    // Assert
    //    await act.Should().ThrowAsync<BusinessException>().WithMessage("Voice ID not found for selected project.");
    //}
    //[Fact]
    //public async Task Handle_ShouldSendEmail_AfterCreatingProject()
    //{
    //    // Arrange
    //    var command = new CreateAiVoiceProjectCommand
    //    {
    //        Name = "Project",
    //        Text = "Sample text",
    //        ArtistId = Guid.NewGuid(),
    //        LanguageId = Guid.NewGuid(),
    //        ProjectSelection = ProjectSelectionEnum.InstantCloneVoice
    //    };

    //    var artist = new Artist { Id = command.ArtistId, InstVoiceId = "inst-voice-id", MailAddress = "artist@example.com" };
    //    var language = new Language { Id = command.LanguageId, LanguageCode = "en" };

    //    _artistServiceMock.Setup(a => a.GetAsync(It.IsAny<Func<Artist, bool>>())).ReturnsAsync(artist);
    //    _languageServiceMock.Setup(l => l.GetAsync(It.IsAny<Func<Language, bool>>())).ReturnsAsync(language);
    //    _emailTemplateServiceMock.Setup(e => e.GetNewAiProjectNotificationEmail(It.IsAny<List<MailboxAddress>>())).Returns(new MimeMessage());

    //    // Act
    //    await _handler.Handle(command, CancellationToken.None);

    //    // Assert
    //    _emailServiceMock.Verify(e => e.SendEmailAsync(It.IsAny<MimeMessage>()), Times.Once);
    //}

    [Fact]
    public async Task Handle_ShouldThrowException_WhenArtistNotFound()
    {
        // Arrange
        var command = new CreateAiVoiceProjectCommand
        {
            Name = "Test Project",
            Text = "Sample Text",
            ArtistId = Guid.NewGuid(),
            LanguageId = Guid.NewGuid(),
            UsageRightId = Guid.NewGuid(),
            ProjectSelection = ProjectSelectionEnum.InstantCloneVoice
        };

        _artistServiceMock
            .Setup(a => a.GetAsync(
                It.IsAny<Expression<Func<Artist, bool>>>(),
                null, // include parametresi null olarak geçildi
                false, // withDeleted parametresi varsayılan değeriyle geçildi
                true, // enableTracking parametresi varsayılan değeriyle geçildi
                It.IsAny<CancellationToken>()))
            .ReturnsAsync((Artist)null);


        // Act
        Func<Task> act = async () => await _handler.Handle(command, default);

        // Assert
        await act.Should()
            .ThrowAsync<BusinessException>()
            .WithMessage("Artist don't exists.");
    }

}

