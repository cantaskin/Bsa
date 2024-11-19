using Domain.Enums;
using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class AiVoiceProject : Project<Guid> 
{
    public ProjectSelectionEnum ProjectSelection { get; set; }
    
    //Prounuanciton için şeyler yüklenecek sadece onlar da eklenmeli.
}
