using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityConfigurations;
public class ArtistUsageRightConfiguration : IEntityTypeConfiguration<ArtistUsageRight>
{
    public void Configure(EntityTypeBuilder<ArtistUsageRight> builder)
    {
        builder.ToTable("ArtistUsageRights").HasKey(aur => aur.Id);

        builder.Property(aur => aur.Id).HasColumnName("Id").IsRequired();
        builder.Property(aur => aur.ArtistId).HasColumnName("ArtistId").IsRequired();
        builder.Property(aur => aur.UsageRightId).HasColumnName("UsageRightId").IsRequired();
        builder.Property(aur => aur.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(aur => aur.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(aur => aur.DeletedDate).HasColumnName("DeletedDate");
        builder.Property(aur => aur.PriceRate).HasColumnName("PriceRate").IsRequired();

        builder.HasQueryFilter(aur => !aur.DeletedDate.HasValue)
            .HasQueryFilter(aur => !aur.Artist.DeletedDate.HasValue)
            .HasQueryFilter(aur => !aur.UsageRight.DeletedDate.HasValue);
    }
}
