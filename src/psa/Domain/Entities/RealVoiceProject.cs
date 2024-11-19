using Domain.Enums;
using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class RealVoiceProject : Project<Guid>
{
    public ICollection<string>? FileUrls { get; set; } 
    public string? Description { get; set; }

    public ProjectSubmissionStatus SubmissionStatus { get; set; }

    public string? RevisionDescription { get; set; }

    //Ekstralar

    //Ve kelimelerin nasıl okunacağı hakkında
}
