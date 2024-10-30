using NArchitecture.Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auth.Dto;
public class UserRegisterDto : IDto
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}
