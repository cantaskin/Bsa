using NArchitecture.Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO;
public class FileSettings : IDto
{
    public Dictionary<string, FileRule> FileRules { get; set; }
}
