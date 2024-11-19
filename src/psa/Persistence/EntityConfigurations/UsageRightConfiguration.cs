using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class UsageRightConfiguration : IEntityTypeConfiguration<UsageRight>
{
    public void Configure(EntityTypeBuilder<UsageRight> builder)
    {
        builder.ToTable("UsageRights").HasKey(ur => ur.Id);

        builder.Property(ur => ur.Id).HasColumnName("Id").IsRequired();
        builder.Property(ur => ur.Name).HasColumnName("Name").IsRequired();
        builder.Property(ur => ur.Description).HasColumnName("Description").IsRequired();
        builder.Property(ur => ur.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ur => ur.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ur => ur.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(ur => !ur.DeletedDate.HasValue);
    }
}