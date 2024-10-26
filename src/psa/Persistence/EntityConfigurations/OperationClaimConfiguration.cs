using Application.Features.Auth.Constants;
using Application.Features.OperationClaims.Constants;
using Application.Features.UserOperationClaims.Constants;
using Application.Features.Users.Constants;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NArchitecture.Core.Security.Constants;
using Application.Features.Artists.Constants;
using Application.Features.Categories.Constants;
using Application.Features.Demoes.Constants;
using Application.Features.Languages.Constants;
using Application.Features.ToneCategories.Constants;
using Application.Features.GenderPsas.Constants;

namespace Persistence.EntityConfigurations;

public class OperationClaimConfiguration : IEntityTypeConfiguration<OperationClaim>
{
    public void Configure(EntityTypeBuilder<OperationClaim> builder)
    {
        builder.ToTable("OperationClaims").HasKey(oc => oc.Id);

        builder.Property(oc => oc.Id).HasColumnName("Id").IsRequired();
        builder.Property(oc => oc.Name).HasColumnName("Name").IsRequired();
        builder.Property(oc => oc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(oc => oc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(oc => oc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(oc => !oc.DeletedDate.HasValue);

        builder.HasData(_seeds);

        builder.HasBaseType((string)null!);
    }

    public static int AdminId => 1;
    private IEnumerable<OperationClaim> _seeds
    {
        get
        {
            yield return new() { Id = AdminId, Name = GeneralOperationClaims.Admin };

            IEnumerable<OperationClaim> featureOperationClaims = getFeatureOperationClaims(AdminId);
            foreach (OperationClaim claim in featureOperationClaims)
                yield return claim;
        }
    }

#pragma warning disable S1854 // Unused assignments should be removed
    private IEnumerable<OperationClaim> getFeatureOperationClaims(int initialId)
    {
        int lastId = initialId;
        List<OperationClaim> featureOperationClaims = new();

        #region Auth
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = AuthOperationClaims.Admin },
                new() { Id = ++lastId, Name = AuthOperationClaims.Read },
                new() { Id = ++lastId, Name = AuthOperationClaims.Write },
                new() { Id = ++lastId, Name = AuthOperationClaims.RevokeToken },
            ]
        );
        #endregion

        #region OperationClaims
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Admin },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Read },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Write },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Create },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Update },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Delete },
            ]
        );
        #endregion

        #region UserOperationClaims
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Admin },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Read },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Write },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Create },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Update },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Delete },
            ]
        );
        #endregion

        #region Users
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = UsersOperationClaims.Admin },
                new() { Id = ++lastId, Name = UsersOperationClaims.Read },
                new() { Id = ++lastId, Name = UsersOperationClaims.Write },
                new() { Id = ++lastId, Name = UsersOperationClaims.Create },
                new() { Id = ++lastId, Name = UsersOperationClaims.Update },
                new() { Id = ++lastId, Name = UsersOperationClaims.Delete },
            ]
        );
        #endregion

        
        #region Artists CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = ArtistsOperationClaims.Admin },
                new() { Id = ++lastId, Name = ArtistsOperationClaims.Read },
                new() { Id = ++lastId, Name = ArtistsOperationClaims.Write },
                new() { Id = ++lastId, Name = ArtistsOperationClaims.Create },
                new() { Id = ++lastId, Name = ArtistsOperationClaims.Update },
                new() { Id = ++lastId, Name = ArtistsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Categories CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = CategoriesOperationClaims.Admin },
                new() { Id = ++lastId, Name = CategoriesOperationClaims.Read },
                new() { Id = ++lastId, Name = CategoriesOperationClaims.Write },
                new() { Id = ++lastId, Name = CategoriesOperationClaims.Create },
                new() { Id = ++lastId, Name = CategoriesOperationClaims.Update },
                new() { Id = ++lastId, Name = CategoriesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Demoes CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = DemoesOperationClaims.Admin },
                new() { Id = ++lastId, Name = DemoesOperationClaims.Read },
                new() { Id = ++lastId, Name = DemoesOperationClaims.Write },
                new() { Id = ++lastId, Name = DemoesOperationClaims.Create },
                new() { Id = ++lastId, Name = DemoesOperationClaims.Update },
                new() { Id = ++lastId, Name = DemoesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        
        #region Languages CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = LanguagesOperationClaims.Admin },
                new() { Id = ++lastId, Name = LanguagesOperationClaims.Read },
                new() { Id = ++lastId, Name = LanguagesOperationClaims.Write },
                new() { Id = ++lastId, Name = LanguagesOperationClaims.Create },
                new() { Id = ++lastId, Name = LanguagesOperationClaims.Update },
                new() { Id = ++lastId, Name = LanguagesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region ToneCategories CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = ToneCategoriesOperationClaims.Admin },
                new() { Id = ++lastId, Name = ToneCategoriesOperationClaims.Read },
                new() { Id = ++lastId, Name = ToneCategoriesOperationClaims.Write },
                new() { Id = ++lastId, Name = ToneCategoriesOperationClaims.Create },
                new() { Id = ++lastId, Name = ToneCategoriesOperationClaims.Update },
                new() { Id = ++lastId, Name = ToneCategoriesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region GenderPsas CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = GenderPsasOperationClaims.Admin },
                new() { Id = ++lastId, Name = GenderPsasOperationClaims.Read },
                new() { Id = ++lastId, Name = GenderPsasOperationClaims.Write },
                new() { Id = ++lastId, Name = GenderPsasOperationClaims.Create },
                new() { Id = ++lastId, Name = GenderPsasOperationClaims.Update },
                new() { Id = ++lastId, Name = GenderPsasOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region GenderPsas CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = GenderPsasOperationClaims.Admin },
                new() { Id = ++lastId, Name = GenderPsasOperationClaims.Read },
                new() { Id = ++lastId, Name = GenderPsasOperationClaims.Write },
                new() { Id = ++lastId, Name = GenderPsasOperationClaims.Create },
                new() { Id = ++lastId, Name = GenderPsasOperationClaims.Update },
                new() { Id = ++lastId, Name = GenderPsasOperationClaims.Delete },
            ]
        );
        #endregion
        
        return featureOperationClaims;
    }
#pragma warning restore S1854 // Unused assignments should be removed
}