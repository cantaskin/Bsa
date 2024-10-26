using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class DemoEntityUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("b4359a99-364d-4c47-94b5-5f5b98e0f199"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1957e2f1-b416-4bd2-9ad6-7b6f5aada81b"));

            migrationBuilder.AddColumn<Guid>(
                name: "ArtistId",
                table: "Demoes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate", "UserName" },
                values: new object[] { new Guid("c8430950-8f3e-40a0-84a6-c0a560295531"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 155, 196, 41, 55, 241, 145, 153, 150, 220, 171, 157, 50, 183, 167, 4, 106, 33, 194, 79, 43, 217, 224, 144, 45, 37, 178, 4, 233, 237, 235, 237, 97, 189, 177, 35, 192, 121, 44, 83, 125, 132, 60, 212, 249, 141, 200, 95, 82, 57, 79, 57, 140, 130, 101, 21, 63, 110, 148, 62, 239, 76, 122, 50, 93 }, new byte[] { 103, 157, 49, 132, 199, 124, 230, 42, 42, 146, 217, 132, 223, 235, 254, 63, 108, 137, 211, 167, 84, 8, 116, 68, 34, 192, 75, 221, 250, 233, 85, 183, 21, 111, 166, 4, 158, 10, 139, 247, 203, 224, 41, 154, 254, 69, 142, 90, 67, 11, 69, 225, 185, 101, 158, 90, 232, 214, 251, 71, 0, 189, 236, 127, 161, 65, 244, 224, 182, 173, 117, 249, 242, 247, 60, 176, 1, 183, 86, 105, 235, 232, 63, 77, 49, 65, 72, 171, 204, 57, 243, 249, 66, 226, 251, 79, 109, 186, 145, 157, 118, 187, 172, 35, 254, 111, 39, 95, 216, 127, 74, 52, 68, 231, 89, 24, 192, 17, 253, 150, 182, 129, 108, 191, 151, 107, 61, 109 }, null, "" });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("48092d3b-2319-46da-adfd-c788fa706fea"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("c8430950-8f3e-40a0-84a6-c0a560295531") });

            migrationBuilder.CreateIndex(
                name: "IX_Demoes_ArtistId",
                table: "Demoes",
                column: "ArtistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Demoes_Artists_ArtistId",
                table: "Demoes",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Demoes_Artists_ArtistId",
                table: "Demoes");

            migrationBuilder.DropIndex(
                name: "IX_Demoes_ArtistId",
                table: "Demoes");

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("48092d3b-2319-46da-adfd-c788fa706fea"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c8430950-8f3e-40a0-84a6-c0a560295531"));

            migrationBuilder.DropColumn(
                name: "ArtistId",
                table: "Demoes");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate", "UserName" },
                values: new object[] { new Guid("1957e2f1-b416-4bd2-9ad6-7b6f5aada81b"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 62, 46, 2, 243, 110, 149, 84, 146, 186, 11, 197, 241, 117, 106, 243, 160, 8, 101, 231, 50, 142, 19, 102, 205, 190, 90, 45, 166, 190, 115, 204, 161, 84, 61, 58, 198, 107, 174, 14, 95, 144, 38, 81, 106, 99, 250, 12, 152, 23, 172, 211, 33, 175, 161, 159, 233, 167, 114, 164, 84, 153, 53, 235, 121 }, new byte[] { 178, 235, 164, 84, 191, 132, 236, 214, 137, 63, 2, 47, 127, 213, 134, 233, 84, 8, 89, 48, 55, 237, 170, 216, 199, 30, 91, 179, 209, 196, 128, 129, 149, 166, 184, 27, 226, 158, 84, 92, 80, 141, 141, 69, 140, 114, 130, 236, 111, 137, 215, 193, 132, 124, 9, 137, 131, 177, 90, 101, 37, 184, 2, 94, 74, 184, 253, 17, 162, 250, 68, 140, 13, 66, 32, 57, 99, 101, 162, 84, 158, 72, 63, 159, 41, 157, 157, 213, 165, 16, 78, 246, 39, 90, 57, 130, 143, 212, 91, 245, 203, 117, 9, 171, 128, 124, 156, 251, 99, 46, 114, 97, 158, 25, 88, 160, 2, 220, 151, 155, 202, 247, 115, 70, 51, 188, 239, 19 }, null, "" });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("b4359a99-364d-4c47-94b5-5f5b98e0f199"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("1957e2f1-b416-4bd2-9ad6-7b6f5aada81b") });
        }
    }
}
