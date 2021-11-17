using Microsoft.EntityFrameworkCore.Migrations;

namespace BankApp.Api.Migrations
{
    public partial class RolesSeedInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94a38271-f979-4a0a-be7e-1178b6fc3d15");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c2151c95-e398-4096-b33a-7293ab82a4e2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "38641fc0-9b44-4b5a-94b1-33efcd60cf32", "ab4d0ce9-b0d2-42f3-be51-c0e8d4288420", "Viewer", "VIEWER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a8a8aa09-d70f-4c31-80b9-7bfd2901d59d", "b13f8429-0082-4dc1-b4fc-b6830674ab8c", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "38641fc0-9b44-4b5a-94b1-33efcd60cf32");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a8a8aa09-d70f-4c31-80b9-7bfd2901d59d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c2151c95-e398-4096-b33a-7293ab82a4e2", "0d6d9c0d-dfdb-49ba-9fe8-ebc8551a6c6f", "customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "94a38271-f979-4a0a-be7e-1178b6fc3d15", "834f9299-8dd3-4b0e-8c63-820db94728aa", "Admin", "ADMIN" });
        }
    }
}
