using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ToneCategoryConfiguration : IEntityTypeConfiguration<ToneCategory>
{
    public void Configure(EntityTypeBuilder<ToneCategory> builder)
    {
        builder.ToTable("ToneCategories").HasKey(tc => tc.Id);

        builder.Property(tc => tc.Id).HasColumnName("Id").IsRequired();
        builder.Property(tc => tc.Name).HasColumnName("Name").IsRequired();
        builder.Property(tc => tc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(tc => tc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(tc => tc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(tc => !tc.DeletedDate.HasValue);
    }
}