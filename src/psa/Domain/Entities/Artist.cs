using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class Artist : Entity<Guid>
{
    public  string UserName { get; set; }
    public string? PhotoUrl { get; set; }
    public  string MailAddress { get; set; }
    public string? YoutubeAddress { get; set; }
    public  float InstAiUnitPrice { get; set; }
    public  float ProfAiUnitPrice { get; set; }
    public  float RealVoiceStampPrice { get; set; }
    public  ICollection<Language> Languages { get; set; }
    
    public  Guid ToneCategoryId { get; set; }
    public  ToneCategory? ToneCategory { get; set; } 

    public Guid GenderPsaId { get; set; }

    public GenderPsa? GenderPsa { get; set; }

    public ICollection<Demo> Demos { get; set; }
}
