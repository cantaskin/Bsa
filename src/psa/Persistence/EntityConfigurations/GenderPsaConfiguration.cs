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

        builder.HasData(_genders);


        builder.HasQueryFilter(gp => !gp.DeletedDate.HasValue);
    }

    private IEnumerable<GenderPsa> _genders
    {
        get
        {
            yield return new GenderPsa
            {
                Id = GuidFinder.Male,
                CreatedDate = DateTime.UtcNow,
                Name = "Male"
            };

            yield return new GenderPsa
            {
                Id = GuidFinder.Female,
                CreatedDate = DateTime.UtcNow,
                Name = "Female"
            };
        }
    }

}