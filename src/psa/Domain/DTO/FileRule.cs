using NArchitecture.Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO;
public class FileRule : IDto
{
    public string[] Extensions { get; set; }
    public string[] MimeTypes { get; set; }
    public long MaxSize { get; set; }
}

