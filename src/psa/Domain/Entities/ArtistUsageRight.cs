using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class ArtistUsageRight : Entity<Guid>
{
    public Guid ArtistId { get; set; }
    public Artist Artist { get; set; }

    public Guid UsageRightId { get; set; }
    public UsageRight UsageRight { get; set; }

    public float PriceRate { get; set; }
}
