using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class Demo : Entity<Guid>
{
    public string Name { get; set; }
    public string Url { get; set; } //4
    public Guid CategoryId { get; set; }
    public Category Category { get; set; }
    public Guid LanguageId { get; set; }
    public Language Language { get; set; }
    public Guid ArtistId { get; set; }
    public Artist Artist { get; set; }
    
}