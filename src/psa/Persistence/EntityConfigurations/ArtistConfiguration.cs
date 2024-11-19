using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NArchitecture.Core.Security.Hashing;
using Org.BouncyCastle.Bcpg;

namespace Persistence.EntityConfigurations;

public class ArtistConfiguration : IEntityTypeConfiguration<Artist>
{
    public void Configure(EntityTypeBuilder<Artist> builder)
    {
        builder.ToTable("Artists").HasKey(a => a.Id);

        builder.Property(a => a.Id).HasColumnName("Id").IsRequired();
        builder.Property(a => a.UserName).HasColumnName("UserName").IsRequired();
        builder.Property(a => a.PhotoUrl).HasColumnName("PhotoUrl");
        builder.Property(a => a.MailAddress).HasColumnName("MailAddress").IsRequired();
        builder.Property(a => a.YoutubeVideosUrl).HasColumnName("YoutubeAddress");
        builder.Property(a => a.InstAiUnitPrice).HasColumnName("InstAiUnitPrice").IsRequired();
        builder.Property(a => a.ProfAiUnitPrice).HasColumnName("ProfAiUnitPrice").IsRequired();
        builder.Property(a => a.RealVoiceStampPrice).HasColumnName("RealVoiceStampPrice").IsRequired();
        builder.Property(a => a.ToneCategoryId).HasColumnName("ToneCategoryId").IsRequired();
        builder.Property(a => a.Gender).HasColumnName("Gender").IsRequired();
        builder.Property(a => a.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(a => a.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(a => a.DeletedDate).HasColumnName("DeletedDate");

        builder.HasData(_artists);

        builder.HasQueryFilter(a => !a.DeletedDate.HasValue);
    }

    private IEnumerable<Artist> _artists
    {

        get
        {
            yield return new Artist
            {
                Id = GuidFinder.Artist1,
                CreatedDate = DateTime.UtcNow,
                UserName = "Artist_1",
                MailAddress = "artist1@example.com",
                InstAiUnitPrice = 100.0f,
                ProfAiUnitPrice = 150.0f,
                RealVoiceStampPrice = 200.0f,
                Gender = GenderEnum.Male,
                ToneCategoryId = GuidFinder.Mature // Olgun
            };

            yield return new Artist
            {
                Id = GuidFinder.Artist2,
                CreatedDate = DateTime.UtcNow,
                UserName = "Artist_2",
                MailAddress = "artist2@example.com",
                InstAiUnitPrice = 105.0f,
                ProfAiUnitPrice = 155.0f,
                RealVoiceStampPrice = 205.0f,
                Gender = GenderEnum.Female,
                ToneCategoryId = GuidFinder.Young // Genç
            };

            yield return new Artist
            {
                Id = GuidFinder.Artist3,
                CreatedDate = DateTime.UtcNow,
                UserName = "Artist_3",
                MailAddress = "artist3@example.com",
                InstAiUnitPrice = 110.0f,
                ProfAiUnitPrice = 160.0f,
                RealVoiceStampPrice = 210.0f,
                Gender = GenderEnum.Male,
                ToneCategoryId = GuidFinder.MiddleAge // Orta Yaþ
            };

            yield return new Artist
            {
                Id = GuidFinder.Artist4,
                CreatedDate = DateTime.UtcNow,
                UserName = "Artist_4",
                MailAddress = "artist4@example.com",
                InstAiUnitPrice = 115.0f,
                ProfAiUnitPrice = 165.0f,
                RealVoiceStampPrice = 215.0f,
                Gender = GenderEnum.Female, // Kadýn
                ToneCategoryId = GuidFinder.Child
            };

            yield return new Artist
            {
                Id = GuidFinder.Artist5,
                CreatedDate = DateTime.UtcNow,
                UserName = "Artist_5",
                MailAddress = "artist5@example.com",
                InstAiUnitPrice = 120.0f,
                ProfAiUnitPrice = 170.0f,
                RealVoiceStampPrice = 220.0f,
                Gender = GenderEnum.Male, // Erkek
                ToneCategoryId = GuidFinder.Mature // Olgun
            };
        }
    }



}