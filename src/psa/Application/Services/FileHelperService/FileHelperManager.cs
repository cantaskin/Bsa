using Application.Services.FileHelperService;
using Domain.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

public class FileHelperManager : IFileHelperService
{
    private readonly string _rootPath;
    private readonly Dictionary<string, FileRule> _fileRules;

    // Kategorileri tanımlıyoruz
    private static string Voices => "Voices";
    private static string ProjectUtilityFiles => "ProjectUtilityFiles";
    private static string Images => "Images";

    public FileHelperManager(IOptions<FileSettings> fileSettings)
    {
        _rootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
        _fileRules = fileSettings.Value.FileRules;
    }

    public async Task<string> UploadAsync(IFormFile file, string folderName, string category)
    {
        ValidateFile(file, category);

        string uploadPath = Path.Combine(_rootPath, folderName);

        if (!Directory.Exists(uploadPath))
            Directory.CreateDirectory(uploadPath);

        string fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
        string filePath = Path.Combine(uploadPath, fileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        string fileUrl = Path.Combine(folderName, fileName).Replace("\\", "/");
        return $"/{fileUrl}";
    }

    private void ValidateFile(IFormFile file, string category)
    {
        if (file == null || file.Length == 0)
            throw new BusinessException("Dosya boş olamaz.");

        if (!_fileRules.ContainsKey(category))
            throw new BusinessException($"'{category}' kategorisi için tanımlanmış dosya kuralları bulunamadı.");

        var rules = _fileRules[category];
        var extension = Path.GetExtension(file.FileName).ToLowerInvariant();

        // Uzantı kontrolü
        if (!rules.Extensions.Contains(extension))
            throw new BusinessException(
                $"Geçersiz dosya formatı. Sadece {string.Join(", ", rules.Extensions)} uzantılı dosyalar kabul edilmektedir."
            );

        // MIME type kontrolü
        if (!rules.MimeTypes.Contains(file.ContentType.ToLowerInvariant()))
            throw new BusinessException("Dosya içeriği geçerli formatta değil.");

        // Boyut kontrolü
        if (file.Length > rules.MaxSize)
            throw new BusinessException($"Dosya boyutu {rules.MaxSize / 1048576}MB'dan büyük olamaz.");
    }

    public async Task<string> UploadVoiceAsync(IFormFile file, string folderName)
    {
        return await UploadAsync(file, folderName, Voices);
    }

    public async Task<string> UploadImageAsync(IFormFile file, string folderName)
    {
        return await UploadAsync(file, folderName, Images);
    }

    public async Task<string> UploadDocumentAsync(IFormFile file, string folderName)
    {
        return await UploadAsync(file, folderName, ProjectUtilityFiles);
    }

    public void Delete(string filePath)
    {
        if (string.IsNullOrEmpty(filePath))
            return;

        string fullPath = Path.Combine(_rootPath, filePath.TrimStart('/'));

        if (File.Exists(fullPath))
            File.Delete(fullPath);
    }
}
