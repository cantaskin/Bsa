using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ArtistConfiguration : IEntityTypeConfiguration<Artist>
{
    public void Configure(EntityTypeBuilder<Artist> builder)
    {
        builder.ToTable("Artists").HasKey(a => a.Id);

        builder.Property(a => a.Id).HasColumnName("Id").IsRequired();
        builder.Property(a => a.UserName).HasColumnName("UserName").IsRequired();
        builder.Property(a => a.PhotoUrl).HasColumnName("PhotoUrl");
        builder.Property(a => a.MailAddress).HasColumnName("MailAddress").IsRequired();
        builder.Property(a => a.YoutubeAddress).HasColumnName("YoutubeAddress");
        builder.Property(a => a.InstAiUnitPrice).HasColumnName("InstAiUnitPrice").IsRequired();
        builder.Property(a => a.ProfAiUnitPrice).HasColumnName("ProfAiUnitPrice").IsRequired();
        builder.Property(a => a.RealVoiceStampPrice).HasColumnName("RealVoiceStampPrice").IsRequired();
        builder.Property(a => a.ToneCategoryId).HasColumnName("ToneCategoryId").IsRequired();
        builder.Property(a => a.GenderPsaId).HasColumnName("GenderPsaId").IsRequired();
        builder.Property(a => a.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(a => a.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(a => a.DeletedDate).HasColumnName("DeletedDate");

;

        builder.HasQueryFilter(a => !a.DeletedDate.HasValue);
    }
}