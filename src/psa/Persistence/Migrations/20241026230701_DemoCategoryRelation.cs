using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class DemoCategoryRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("c245c9aa-9f83-42e6-82b1-41c4d42d7576"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("796e8d1a-b43d-4464-b03f-c9272599c22b"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate", "UserName" },
                values: new object[] { new Guid("4b544eac-806a-434e-bf8c-4511e4251f3c"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 220, 235, 166, 199, 169, 162, 40, 235, 19, 139, 75, 168, 136, 31, 212, 198, 251, 104, 214, 187, 48, 7, 211, 196, 49, 90, 249, 62, 229, 192, 196, 132, 30, 121, 188, 178, 151, 200, 107, 122, 137, 244, 117, 107, 27, 89, 150, 236, 106, 142, 164, 64, 184, 70, 215, 113, 225, 219, 55, 44, 47, 190, 242, 137 }, new byte[] { 223, 84, 86, 15, 56, 96, 9, 54, 132, 12, 101, 47, 166, 135, 22, 15, 240, 0, 125, 93, 198, 62, 142, 224, 191, 78, 65, 23, 177, 217, 195, 71, 26, 172, 153, 255, 63, 250, 49, 247, 130, 182, 3, 43, 90, 138, 204, 83, 72, 169, 84, 184, 152, 67, 251, 128, 217, 216, 77, 69, 125, 62, 86, 22, 52, 62, 100, 217, 200, 215, 113, 106, 46, 24, 142, 255, 94, 108, 186, 127, 50, 141, 30, 3, 125, 53, 143, 247, 226, 215, 237, 203, 4, 205, 26, 36, 228, 117, 6, 234, 127, 241, 250, 183, 36, 14, 206, 176, 187, 197, 100, 36, 115, 77, 231, 135, 143, 65, 61, 254, 148, 82, 64, 114, 125, 166, 171, 143 }, null, "" });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("455a3bd2-3bde-47dd-b366-b21d4c4f00e3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("4b544eac-806a-434e-bf8c-4511e4251f3c") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("455a3bd2-3bde-47dd-b366-b21d4c4f00e3"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("4b544eac-806a-434e-bf8c-4511e4251f3c"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate", "UserName" },
                values: new object[] { new Guid("796e8d1a-b43d-4464-b03f-c9272599c22b"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 142, 136, 253, 240, 53, 68, 227, 35, 77, 125, 221, 134, 224, 48, 241, 210, 225, 87, 251, 50, 135, 22, 119, 157, 174, 178, 163, 183, 18, 98, 225, 22, 150, 80, 80, 120, 58, 154, 78, 55, 47, 118, 121, 119, 129, 165, 154, 100, 52, 38, 249, 185, 246, 55, 99, 243, 150, 162, 26, 191, 63, 24, 236, 4 }, new byte[] { 4, 104, 180, 53, 223, 35, 248, 7, 84, 46, 0, 4, 100, 1, 68, 6, 211, 3, 24, 24, 101, 240, 201, 158, 245, 114, 164, 174, 72, 235, 1, 182, 209, 76, 159, 120, 66, 101, 218, 224, 32, 47, 186, 216, 215, 36, 102, 52, 11, 234, 113, 56, 6, 13, 63, 16, 81, 167, 86, 28, 197, 162, 64, 222, 157, 203, 73, 83, 49, 20, 3, 252, 18, 212, 68, 52, 46, 99, 178, 166, 184, 236, 238, 21, 79, 123, 173, 64, 129, 157, 175, 215, 16, 34, 132, 54, 112, 242, 17, 44, 101, 144, 175, 44, 136, 174, 123, 200, 229, 253, 208, 129, 227, 46, 230, 26, 167, 150, 50, 230, 172, 220, 240, 91, 146, 220, 45, 84 }, null, "" });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("c245c9aa-9f83-42e6-82b1-41c4d42d7576"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("796e8d1a-b43d-4464-b03f-c9272599c22b") });
        }
    }
}
