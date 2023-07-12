using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PasskeyLoginPOC.API.Migrations
{
    /// <inheritdoc />
    public partial class SeededDefaultUserandRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "03152af0-a8d8-4278-bb2c-4b7ebe31c6e1", "ec078041-2449-4bb8-a180-a087c0b69889", "User", "USER" },
                    { "63a59036-8ab1-443f-ac74-3b475cfab954", "a91c51e6-099c-477a-b056-7de109245fcc", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "MachineName", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "282c18e6-292f-4fbc-9265-ac6dc91f0171", 0, "5a60e269-7cd9-4aaf-bd9b-c7b25a875253", null, false, false, null, "USER", "User", null, null, null, "07717133825", false, "2b2dda2f-5f43-4a5c-87f7-e8c30a74bdfb", false, null },
                    { "6ddb6ae6-6fe3-46a0-9530-2504eb3a65c4", 0, "daf045dc-673c-487a-9ef9-c094f68f34e2", null, false, false, null, "ETZ_LAPTOP_01", "Admin", null, null, null, "07717133825", false, "79ec4d97-6c91-4f84-b55c-ac2f56bc11f1", false, null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "03152af0-a8d8-4278-bb2c-4b7ebe31c6e1", "282c18e6-292f-4fbc-9265-ac6dc91f0171" },
                    { "63a59036-8ab1-443f-ac74-3b475cfab954", "6ddb6ae6-6fe3-46a0-9530-2504eb3a65c4" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "03152af0-a8d8-4278-bb2c-4b7ebe31c6e1", "282c18e6-292f-4fbc-9265-ac6dc91f0171" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "63a59036-8ab1-443f-ac74-3b475cfab954", "6ddb6ae6-6fe3-46a0-9530-2504eb3a65c4" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03152af0-a8d8-4278-bb2c-4b7ebe31c6e1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "63a59036-8ab1-443f-ac74-3b475cfab954");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "282c18e6-292f-4fbc-9265-ac6dc91f0171");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6ddb6ae6-6fe3-46a0-9530-2504eb3a65c4");
        }
    }
}
