using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("271e58d3-fd2e-4c37-95bf-f6d9e7015905"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("4d58487a-5cc2-41ed-b24a-d265d6cabd5c"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FullName", "Password", "Role" },
                values: new object[,]
                {
                    { new Guid("95ed9d38-3239-4c3a-a319-34a5f42c49e3"), "Admin@Test.com", "Admin", "$2a$11$ASaqrgVW3lBlqU5cusgoIOzcQhsxRcqv/c7EQInMd.pkQNvTyjpEC", "Admin" },
                    { new Guid("a280ed6e-89aa-42b4-b80f-80a55c7916ab"), "Employee@Test.com", "Employee", "$2a$11$JkQLUOIddfe6kncslvVxZ..8mYvABxqRlIQsZC/rb1aJA7Jv0ExKa", "Employee" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("95ed9d38-3239-4c3a-a319-34a5f42c49e3"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a280ed6e-89aa-42b4-b80f-80a55c7916ab"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FullName", "Password", "Role" },
                values: new object[,]
                {
                    { new Guid("271e58d3-fd2e-4c37-95bf-f6d9e7015905"), "Admin@Test.com", "Admin", "$2a$11$ASaqrgVW3lBlqU5cusgoIOzcQhsxRcqv/c7EQInMd.pkQNvTyjpEC", "Admin" },
                    { new Guid("4d58487a-5cc2-41ed-b24a-d265d6cabd5c"), "Employee@Test.com", "Employee", "$2a$11$JkQLUOIddfe6kncslvVxZ..8mYvABxqRlIQsZC/rb1aJA7Jv0ExKa", "Employee" }
                });
        }
    }
}
