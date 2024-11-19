using Application.Services.ImageService;
using Application.Services.MailService;
using Application.Services.SpeechsService;
using Infrastructure.Adapters.ImageService;
using Infrastructure.Adapters.MailService;
using Infrastructure.Adapters.SpeechService;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<ImageServiceBase, CloudinaryImageServiceAdapter>();
        services.AddScoped<IEMailService, FluentMailServiceAdapter>();
        services.AddScoped<ISpeechService, ElevenLabsSpeechServiceAdapter>();
        return services;
    }
}
