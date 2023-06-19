using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookApp.API.Migrations
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
                    { "0d1f348c-3b6d-4ba2-88ea-68e9115555c4", "21b4b53d-9b27-42ee-92a9-01690d49ca33", "User", "USER" },
                    { "a2a927d3-bfbf-4462-be5c-fbf9f8e219d7", "9bb47379-a24d-4641-96be-184088f8fe58", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "5db797d8-eb31-4d89-a6e3-e21782635fac", 0, "1708c04f-1523-4ea0-b2c9-3f7139fde44e", "user@bookstore.com", false, "System", "User", false, null, "USER@BOOKSTORE.COM", "USER@BOOKSTORE.COM", "AQAAAAEAACcQAAAAENhVkWD8P6eErmWapvynwygrslwZ9ird7MvjQiiJXvBmgj3Aredm6QcTiTuRd+gG/g==", null, false, "f400c592-9c80-4401-95c6-1dc760311095", false, "user@bookstore.com" },
                    { "9e46c42f-84c5-47b8-aea5-5b292ac363bc", 0, "57ebae95-a196-490f-bd6c-a3703d07a4f4", "admin@bookstore.com", false, "System", "Admin", false, null, "ADMIN@BOOKSTORE.COM", "ADMIN@BOOKSTORE.COM", "AQAAAAEAACcQAAAAEIStBb7mXuWgZDZBv/pmw37SYVewjzTIynWxzqAw+GuZVEoftg5mqT6HAxV+f08SDg==", null, false, "373159a2-e99c-4b00-afa0-b143b9e99de2", false, "admin@bookstore.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "0d1f348c-3b6d-4ba2-88ea-68e9115555c4", "5db797d8-eb31-4d89-a6e3-e21782635fac" },
                    { "a2a927d3-bfbf-4462-be5c-fbf9f8e219d7", "9e46c42f-84c5-47b8-aea5-5b292ac363bc" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0d1f348c-3b6d-4ba2-88ea-68e9115555c4", "5db797d8-eb31-4d89-a6e3-e21782635fac" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a2a927d3-bfbf-4462-be5c-fbf9f8e219d7", "9e46c42f-84c5-47b8-aea5-5b292ac363bc" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0d1f348c-3b6d-4ba2-88ea-68e9115555c4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a2a927d3-bfbf-4462-be5c-fbf9f8e219d7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5db797d8-eb31-4d89-a6e3-e21782635fac");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e46c42f-84c5-47b8-aea5-5b292ac363bc");
        }
    }
}
