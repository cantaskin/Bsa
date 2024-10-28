using Domain.Entities;
using NArchitecture.Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Demoes.Queries.GetDynamicList;
public class GetDynamicListDemoandArtistUnitedItemDto : IDto
{
    public string Name { get; set; }
    public string Url { get; set; }
    public Guid CategoryId { get; set; }
    public Guid LanguageId { get; set; }
    public Guid ArtistId { get; set; }
    public string UserName { get; set; }
    public string? PhotoUrl { get; set; }
    public float InstAiUnitPrice { get; set; }
    public float ProfAiUnitPrice { get; set; }
    public float RealVoiceStampPrice { get; set; }
    public Guid ToneCategoryId { get; set; }
    public Guid GenderPsaId { get; set; }
}
