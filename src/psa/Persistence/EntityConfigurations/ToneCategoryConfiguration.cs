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

        builder.HasData(_toneCategories);

        builder.HasQueryFilter(tc => !tc.DeletedDate.HasValue);
    }

    private IEnumerable<ToneCategory> _toneCategories
    {
        get
        {
            yield return new ToneCategory
            {
                Id = new Guid("6b735582-018e-4d47-b3be-b4bc30411716"),
                Name = "Olgun"
            };

            yield return new ToneCategory
            {
                Id = new Guid("a4498d12-306c-4e45-9f22-259145662794"),
                Name = "Genç"
            };

            yield return new ToneCategory
            {
                Id = new Guid("9573dbf0-d69a-4dfb-86c5-83cf863e4055"),
                Name = "Orta Yaþ"
            };

            yield return new ToneCategory
            {
                Id = new Guid("75f62356-5710-4166-b77e-a9ec54367be8"),
                Name = "Çocuk"
            };
        }
    }

}