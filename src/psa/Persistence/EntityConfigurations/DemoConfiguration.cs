using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class DemoConfiguration : IEntityTypeConfiguration<Demo>
{
    public void Configure(EntityTypeBuilder<Demo> builder)
    {
        builder.ToTable("Demoes").HasKey(d => d.Id);

        builder.Property(d => d.Id).HasColumnName("Id").IsRequired();
        builder.Property(d => d.Name).HasColumnName("Name").IsRequired();
        builder.Property(d => d.Url).HasColumnName("Url").IsRequired();
        builder.Property(d => d.CategoryId).HasColumnName("CategoryId").IsRequired();
        builder.Property(d => d.ArtistId).HasColumnName("ArtistId").IsRequired();
        builder.Property(d => d.LanguageId).HasColumnName("LanguageId").IsRequired();
        builder.Property(d => d.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(d => d.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(d => d.DeletedDate).HasColumnName("DeletedDate");

        builder.HasOne(d => d.Category).WithMany(c => c.Demos).HasForeignKey(d => d.CategoryId);

        builder.HasQueryFilter(d => !d.DeletedDate.HasValue);
    }
}