using Microsoft.EntityFrameworkCore.Migrations;

namespace BankApp.Api.Migrations
{
    public partial class _3CorrectingRolesSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "b29acd41-03f1-4e61-9118-19e90b170330", "4675ccef-fde3-4751-8c15-707127b41c64", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "916c7bfd-7cda-4aa2-bede-7233f49f6cc4", "391c7753-88d9-4083-84b6-3994062a2a0c", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "916c7bfd-7cda-4aa2-bede-7233f49f6cc4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b29acd41-03f1-4e61-9118-19e90b170330");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8ce99960-c00b-4da2-bad7-69ca8e28c5b7", "32e126b1-b855-4ed6-8a63-a88a95e6ad32", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "edbd1397-0af0-4a60-94f0-677bc9c4102c", "0909e4f2-fd6a-4ef8-a29c-2a709f2ec99d", "Administrator", "ADMINISTRATOR" });
        }
    }
}
