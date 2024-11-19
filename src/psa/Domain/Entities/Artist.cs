using Domain.Enums;
using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class Artist : Entity<Guid>
{
    public  string UserName { get; set; }
    public string? PhotoUrl { get; set; } //1
    public string MailAddress { get; set; }
    public IList<string>? YoutubeVideosUrl { get; set; }

    public string? InstVoiceId { get; set; }
    
    public string? ProfVoiceId { get; set; }
    public  float InstAiUnitPrice { get; set; }
    public  float ProfAiUnitPrice { get; set; }
    public  float RealVoiceStampPrice { get; set; }
    public  ICollection<Language> Languages { get; set; }
    
    public  Guid ToneCategoryId { get; set; }
    public  ToneCategory? ToneCategory { get; set; } 

    public GenderEnum Gender { get; set; }
    public ICollection<ArtistUsageRight>? ArtistUsageRights { get; set; }
    public ICollection<Demo> Demos { get; set; }
}
