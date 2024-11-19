using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class AiVoiceProjectConfiguration : IEntityTypeConfiguration<AiVoiceProject>
{
    public void Configure(EntityTypeBuilder<AiVoiceProject> builder)
    {
        builder.ToTable("AiVoiceProjects").HasKey(avp => avp.Id);

        builder.Property(avp => avp.Id).HasColumnName("Id").IsRequired();
        builder.Property(avp => avp.Name).HasColumnName("Name").IsRequired();
        builder.Property(avp => avp.Text).HasColumnName("Text").IsRequired();
        builder.Property(avp => avp.Url).HasColumnName("Url");
        builder.Property(avp => avp.ArtistId).HasColumnName("ArtistId").IsRequired();
        builder.Property(avp => avp.LanguageId).HasColumnName("LanguageId").IsRequired();
        builder.Property(avp => avp.UsageRightId).HasColumnName("UsageRightId").IsRequired();
        builder.Property(avp => avp.ProjectSelection).HasColumnName("ProjectSelection").IsRequired();
        builder.Property(avp => avp.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(avp => avp.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(avp => avp.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(avp => !avp.DeletedDate.HasValue);
    }
}