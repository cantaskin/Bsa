using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class DemoConfiguration : IEntityTypeConfiguration<Demo>
{
    public void Configure(EntityTypeBuilder<Demo> builder)
    {
        builder.ToTable("Demoes").HasKey(d => d.Id);

        builder.Property(d => d.Id).HasColumnName("Id").IsRequired();
        builder.Property(d => d.Name).HasColumnName("Name").IsRequired();
        builder.Property(d => d.Url).HasColumnName("Url").IsRequired();
        builder.Property(d => d.CategoryId).HasColumnName("CategoryId").IsRequired();
        builder.Property(d => d.ArtistId).HasColumnName("ArtistId").IsRequired();
        builder.Property(d => d.LanguageId).HasColumnName("LanguageId").IsRequired();
        builder.Property(d => d.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(d => d.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(d => d.DeletedDate).HasColumnName("DeletedDate");

        builder.HasData(_demos);
        builder.HasOne(d => d.Category).WithMany(c => c.Demos).HasForeignKey(d => d.CategoryId);

        builder.HasQueryFilter(d => !d.DeletedDate.HasValue);
    }

    private IEnumerable<Demo> _demos
    {
        get
        {
            yield return new Demo
            {
                Id = GuidFinder.Demo1,
                Name = "Demo Track 1",
                Url = "https://example.com/demo1",
                CategoryId = GuidFinder.Advertising, // Music category
                LanguageId = GuidFinder.English, // English language
                ArtistId = GuidFinder.Artist1, // Örnek artist id
            };

            yield return new Demo
            {
                Id = GuidFinder.Demo2,
                Name = "Demo Track 2",
                Url = "https://example.com/demo2",
                CategoryId = GuidFinder.Central, // Podcast category
                LanguageId = GuidFinder.Spanish, // Spanish language
                ArtistId = GuidFinder.Artist2, // Örnek artist id
            };

            yield return new Demo
            {
                Id = GuidFinder.Demo3,
                Name = "Demo Track 3",
                Url = "https://example.com/demo3",
                CategoryId = GuidFinder.Documentary, // Audiobook category
                LanguageId = GuidFinder.French, // French language
                ArtistId = GuidFinder.Artist3, // Örnek artist id
            };

            yield return new Demo
            {
                Id = GuidFinder.Demo4,
                Name = "Demo Track 4",
                Url = "https://example.com/demo4",
                CategoryId = GuidFinder.Dubbing, // Lecture category
                LanguageId = GuidFinder.German, // German language
                ArtistId = GuidFinder.Artist3,// Örnek artist id
            };

            yield return new Demo
            {
                Id = GuidFinder.Demo5,
                Name = "Demo Track 5",
                Url = "https://example.com/demo5",
                CategoryId = GuidFinder.Jingle, // Sound Effects category
                LanguageId = GuidFinder.Japanese, // Japanese language
                ArtistId = GuidFinder.Artist5, // Örnek artist id
            };
        }
    }

}