using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class LanguageConfiguration : IEntityTypeConfiguration<Language>
{
    public void Configure(EntityTypeBuilder<Language> builder)
    {
        builder.ToTable("Languages").HasKey(l => l.Id);

        builder.Property(l => l.Id).HasColumnName("Id").IsRequired();
        builder.Property(l => l.Name).HasColumnName("Name").IsRequired();
        builder.Property(l => l.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(l => l.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(l => l.DeletedDate).HasColumnName("DeletedDate");

        builder.HasData(_languages);

        builder.HasQueryFilter(l => !l.DeletedDate.HasValue);
    }

    private IEnumerable<Language> _languages
    {
        get
        {
            yield return new Language
            {
                Id = new Guid("2f608f15-f672-4f88-989f-21eeb522e931"),
                Name = "English"
            };

            yield return new Language
            {
                Id = new Guid("b466599c-338b-4b0f-b908-2bd388575dc5"),
                Name = "Spanish"
            };

            yield return new Language
            {
                Id = new Guid("69dd6dfd-9cc6-43ba-a24a-bde4f3452b73"),
                Name = "French"
            };

            yield return new Language
            {
                Id = new Guid("05bcb769-f369-4231-a78c-18ccbb7648da"),
                Name = "German"
            };

            yield return new Language
            {
                Id = new Guid("f8f7d383-d887-4034-9352-90143afc1a8a"),
                Name = "Japanese"
            };
        }
    }

}