using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class GenderPsaConfiguration : IEntityTypeConfiguration<GenderPsa>
{
    public void Configure(EntityTypeBuilder<GenderPsa> builder)
    {
        builder.ToTable("GenderPsas").HasKey(gp => gp.Id);

        builder.Property(gp => gp.Id).HasColumnName("Id").IsRequired();
        builder.Property(gp => gp.Name).HasColumnName("Name").IsRequired();
        builder.Property(gp => gp.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(gp => gp.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(gp => gp.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(gp => !gp.DeletedDate.HasValue);
    }
}