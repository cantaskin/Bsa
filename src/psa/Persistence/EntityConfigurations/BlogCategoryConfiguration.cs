using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class BlogCategoryConfiguration : IEntityTypeConfiguration<BlogCategory>
{
    public void Configure(EntityTypeBuilder<BlogCategory> builder)
    {
        builder.ToTable("BlogCategories").HasKey(bc => bc.Id);

        builder.Property(bc => bc.Id).HasColumnName("Id").IsRequired();
        builder.Property(bc => bc.Name).HasColumnName("Name").IsRequired();
        builder.Property(bc => bc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(bc => bc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(bc => bc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(bc => !bc.DeletedDate.HasValue);
    }
}