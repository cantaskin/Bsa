using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ArtistEntityAddedDemosCollection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("48092d3b-2319-46da-adfd-c788fa706fea"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c8430950-8f3e-40a0-84a6-c0a560295531"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate", "UserName" },
                values: new object[] { new Guid("a643bfc7-38e6-4372-9d35-712d19c6f5b1"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 189, 26, 26, 92, 5, 246, 116, 79, 30, 241, 151, 244, 68, 219, 118, 229, 185, 62, 226, 161, 221, 32, 97, 40, 25, 221, 251, 72, 195, 162, 188, 17, 248, 83, 68, 198, 67, 142, 150, 236, 215, 228, 199, 178, 252, 34, 103, 110, 123, 204, 106, 122, 185, 34, 97, 113, 191, 237, 143, 84, 109, 114, 25, 86 }, new byte[] { 77, 214, 73, 90, 8, 125, 215, 1, 21, 200, 235, 38, 55, 88, 104, 117, 48, 161, 14, 40, 40, 56, 199, 143, 204, 236, 23, 187, 59, 220, 3, 22, 23, 69, 103, 192, 247, 172, 223, 239, 161, 211, 221, 120, 162, 29, 14, 135, 22, 120, 73, 246, 81, 158, 21, 169, 145, 103, 7, 171, 89, 229, 220, 221, 116, 15, 217, 208, 95, 12, 41, 143, 84, 165, 185, 187, 252, 206, 210, 253, 229, 228, 236, 47, 219, 21, 212, 245, 136, 240, 30, 32, 112, 236, 58, 217, 1, 203, 88, 169, 96, 139, 163, 12, 219, 68, 135, 25, 106, 31, 66, 150, 207, 136, 123, 75, 149, 203, 157, 69, 202, 40, 200, 93, 193, 91, 238, 126 }, null, "" });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("52ef08dd-c9aa-4258-ae33-fb5259eabaa8"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("a643bfc7-38e6-4372-9d35-712d19c6f5b1") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("52ef08dd-c9aa-4258-ae33-fb5259eabaa8"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a643bfc7-38e6-4372-9d35-712d19c6f5b1"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate", "UserName" },
                values: new object[] { new Guid("c8430950-8f3e-40a0-84a6-c0a560295531"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 155, 196, 41, 55, 241, 145, 153, 150, 220, 171, 157, 50, 183, 167, 4, 106, 33, 194, 79, 43, 217, 224, 144, 45, 37, 178, 4, 233, 237, 235, 237, 97, 189, 177, 35, 192, 121, 44, 83, 125, 132, 60, 212, 249, 141, 200, 95, 82, 57, 79, 57, 140, 130, 101, 21, 63, 110, 148, 62, 239, 76, 122, 50, 93 }, new byte[] { 103, 157, 49, 132, 199, 124, 230, 42, 42, 146, 217, 132, 223, 235, 254, 63, 108, 137, 211, 167, 84, 8, 116, 68, 34, 192, 75, 221, 250, 233, 85, 183, 21, 111, 166, 4, 158, 10, 139, 247, 203, 224, 41, 154, 254, 69, 142, 90, 67, 11, 69, 225, 185, 101, 158, 90, 232, 214, 251, 71, 0, 189, 236, 127, 161, 65, 244, 224, 182, 173, 117, 249, 242, 247, 60, 176, 1, 183, 86, 105, 235, 232, 63, 77, 49, 65, 72, 171, 204, 57, 243, 249, 66, 226, 251, 79, 109, 186, 145, 157, 118, 187, 172, 35, 254, 111, 39, 95, 216, 127, 74, 52, 68, 231, 89, 24, 192, 17, 253, 150, 182, 129, 108, 191, 151, 107, 61, 109 }, null, "" });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("48092d3b-2319-46da-adfd-c788fa706fea"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("c8430950-8f3e-40a0-84a6-c0a560295531") });
        }
    }
}
