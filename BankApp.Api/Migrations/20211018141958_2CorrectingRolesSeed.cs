using Microsoft.EntityFrameworkCore.Migrations;

namespace BankApp.Api.Migrations
{
    public partial class _2CorrectingRolesSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "8ce99960-c00b-4da2-bad7-69ca8e28c5b7", "32e126b1-b855-4ed6-8a63-a88a95e6ad32", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "edbd1397-0af0-4a60-94f0-677bc9c4102c", "0909e4f2-fd6a-4ef8-a29c-2a709f2ec99d", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8ce99960-c00b-4da2-bad7-69ca8e28c5b7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "edbd1397-0af0-4a60-94f0-677bc9c4102c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "02e3cd1e-ac9e-4dda-aa4c-16dca09b34e0", "664fc5ba-6ca8-40dc-8dc4-b8c5ba4770ea", "Viewer", "VIEWER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6b61103f-eac3-4680-89ec-3289658b3df8", "bc4973c2-8fe4-467d-b821-43ac0f9e3824", "Administrator", "ADMINISTRATOR" });
        }
    }
}
