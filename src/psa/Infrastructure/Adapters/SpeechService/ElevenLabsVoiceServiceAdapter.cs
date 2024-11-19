using Application.Services.FileHelperService;
using Application.Services.SpeechsService;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.Text.Json;

namespace Infrastructure.Adapters.SpeechService;

public class ElevenLabsSpeechServiceAdapter : ISpeechService
{

    private readonly string ApiKey;
    private readonly IConfiguration _configuration;

    public ElevenLabsSpeechServiceAdapter(IConfiguration configuration)
    {
        _configuration = configuration.GetSection("ElevenLabsSetting");
        ApiKey = _configuration["ApiKey"];
    }

    public async Task<string> TextToSpeechAsync(string text, string? VoiceId, string languageCode)
    {
        string ApiUrl = $"https://api.elevenlabs.io/v1/text-to-speech/{VoiceId}";
        using var client = new HttpClient();
        client.DefaultRequestHeaders.Add("xi-api-key", ApiKey);

        var requestBody = new
        {
            text = text,
            model_id = _configuration["model_id"],
            // language_code = languageCode,
            voice_settings = new { stability = 0.5, similarity_boost = 0.75 },
        };

        var content = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");
        var response = await client.PostAsync(ApiUrl, content);


        if (response.IsSuccessStatusCode)
        {
            var audioBytes = await response.Content.ReadAsByteArrayAsync();

            string folderPath = Path.Combine(Environment.CurrentDirectory, FileNames.wwwroot, FileNames.SpeechOutput);

            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            string filePath = Path.Combine(folderPath, $"{Guid.NewGuid()}.mp3");

            await File.WriteAllBytesAsync(filePath, audioBytes);

            return filePath;
        }
        else
            {
                string errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception(errorMessage);
            }
        }
}
