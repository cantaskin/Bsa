using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Application.Services.FileHelperService
{
    public interface IFileHelperService
    {
        public Task<string> UploadAsync(IFormFile file, string folderName, string category);
        public Task<string> UploadVoiceAsync(IFormFile file, string folderName);
        public Task<string> UploadImageAsync(IFormFile file, string folderName);

        public Task<string> UploadDocumentAsync(IFormFile file, string folderName);
        void Delete(string filePath);
    }

}
