using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Categories").HasKey(c => c.Id);

        builder.Property(c => c.Id).HasColumnName("Id").IsRequired();
        builder.Property(c => c.Name).HasColumnName("Name").IsRequired();
        builder.Property(c => c.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(c => c.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(c => c.DeletedDate).HasColumnName("DeletedDate");

        builder.HasData(_categories);
        builder.HasQueryFilter(c => !c.DeletedDate.HasValue);
    }

    private IEnumerable<Category> _categories
    {
        get
        {
            yield return new Category
            {
                Id = GuidFinder.Documentary,
                Name = "Belgesel"
            };

            yield return new Category
            {
                Id = GuidFinder.Jingle,
                Name = "Jingle"
            };

            yield return new Category
            {
                Id = GuidFinder.Dubbing,
                Name = "Dublaj"
            };

            yield return new Category
            {
                Id = GuidFinder.Advertising,
                Name = "Reklam"
            };

            yield return new Category
            {
                Id = GuidFinder.Central,
                Name = "Santral"
            };
        }
    }

}