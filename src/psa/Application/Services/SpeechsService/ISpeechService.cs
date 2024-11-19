namespace Application.Services.SpeechsService;
public interface ISpeechService
{
    public Task<string> TextToSpeechAsync(string text,string? voiceId, string languageCode);
}
