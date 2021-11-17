using Microsoft.EntityFrameworkCore.Migrations;

namespace BankApp.Api.Migrations
{
    public partial class CorrectingRolesSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "02e3cd1e-ac9e-4dda-aa4c-16dca09b34e0", "664fc5ba-6ca8-40dc-8dc4-b8c5ba4770ea", "Viewer", "VIEWER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6b61103f-eac3-4680-89ec-3289658b3df8", "bc4973c2-8fe4-467d-b821-43ac0f9e3824", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "02e3cd1e-ac9e-4dda-aa4c-16dca09b34e0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6b61103f-eac3-4680-89ec-3289658b3df8");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "38641fc0-9b44-4b5a-94b1-33efcd60cf32", "ab4d0ce9-b0d2-42f3-be51-c0e8d4288420", "Viewer", "VIEWER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a8a8aa09-d70f-4c31-80b9-7bfd2901d59d", "b13f8429-0082-4dc1-b4fc-b6830674ab8c", "Administrator", "ADMINISTRATOR" });
        }
    }
}
