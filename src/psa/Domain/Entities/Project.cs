using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public abstract class Project<TId> : Entity<TId>
{
    public string Name { get; set; }
    public string Text { get; set; }
    public string? Url { get; set; }
    public Guid ArtistId { get; set; }
    public Artist Artist { get; set; }
    public Guid LanguageId { get; set; }
    public Language Language { get; set; }
    public Guid UsageRightId { get; set; }
    public UsageRight UsageRight { get; set; }
    public Guid? DemoId { get; set; } //Eğer kullanıcı bir demodan gelmişse bunun verisini tutmak işime yarayabilir.
    public Demo? Demo { get; set; }
}
