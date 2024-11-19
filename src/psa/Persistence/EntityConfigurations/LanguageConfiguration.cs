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
                Name = "Ýngilizce",
                LanguageCode = "en"
            };

            yield return new Language
            {
                Id = new Guid("b466599c-338b-4b0f-b908-2bd388575dc5"),
                Name = "Ýspanyolca",
                LanguageCode = "es"
            };

            yield return new Language
            {
                Id = new Guid("69dd6dfd-9cc6-43ba-a24a-bde4f3452b73"),
                Name = "Fransýzca",
                LanguageCode = "fr"
            };

            yield return new Language
            {
                Id = new Guid("05bcb769-f369-4231-a78c-18ccbb7648da"),
                Name = "Almanca",
                LanguageCode = "de"
            };

            yield return new Language
            {
                Id = new Guid("f8f7d383-d887-4034-9352-90143afc1a8a"),
                Name = "Japonca",
                LanguageCode = "ja"
            };

            yield return new Language
            {
                Id = new Guid("8151ab74-7b00-4d3e-8fde-af3a394404b3"),
                Name = "Türkçe",
                LanguageCode = "tr"
            };

            yield return new Language
            {
                Id = new Guid("e26b8af8-b70c-4482-ba89-5737a7bac3a8"),
                Name = "Ýtalyanca",
                LanguageCode = "it"
            };

            yield return new Language
            {
                Id = new Guid("5c69a048-a67b-4cb8-a3ef-3766c7f40b5a"),
                Name = "Arapça",
                LanguageCode = "ar"
            };

            yield return new Language
            {
                Id = new Guid("75264907-d0d8-4de5-9883-83dbcf40e9ce"),
                Name = "Rusça",
                LanguageCode = "ru"
            };

            yield return new Language
            {
                Id = new Guid("aefcbc93-2a8e-408f-918f-b6e1f9666e6f"),
                Name = "Çince",
                LanguageCode = "zh"
            };


        }
    }

}