using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class RealVoiceProjectConfiguration : IEntityTypeConfiguration<RealVoiceProject>
{
    public void Configure(EntityTypeBuilder<RealVoiceProject> builder)
    {
        builder.ToTable("RealVoiceProjects").HasKey(rvp => rvp.Id);

        builder.Property(rvp => rvp.Id).HasColumnName("Id").IsRequired();
        builder.Property(rvp => rvp.Name).HasColumnName("Name").IsRequired();
        builder.Property(rvp => rvp.Text).HasColumnName("Text").IsRequired();
        builder.Property(rvp => rvp.Url).HasColumnName("Url");
        builder.Property(rvp => rvp.ArtistId).HasColumnName("ArtistId").IsRequired();
        builder.Property(rvp => rvp.LanguageId).HasColumnName("LanguageId").IsRequired();
        builder.Property(rvp => rvp.UsageRightId).HasColumnName("UsageRightId").IsRequired();
        builder.Property(rvp => rvp.DemoId).HasColumnName("DemoId");
        builder.Property(rvp => rvp.Description).HasColumnName("Description");
        builder.Property(rvp => rvp.SubmissionStatus).HasColumnName("SubmissionStatus").IsRequired();
        builder.Property(rvp => rvp.RevisionDescription).HasColumnName("RevisionDescription");
        builder.Property(rvp => rvp.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(rvp => rvp.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(rvp => rvp.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(rvp => !rvp.DeletedDate.HasValue);
    }
}