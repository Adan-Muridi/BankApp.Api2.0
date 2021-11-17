using Microsoft.EntityFrameworkCore.Migrations;

namespace BankApp.Api.Migrations
{
    public partial class InitNyaBankenCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "b35b410f-9eee-43bd-9126-b077ef0f2180", "37286057-4ae2-4206-ab6a-5c165b6f7e88", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3ee779a5-069d-4283-8419-54eaffdc5ef4", "2fd918f1-83cb-41e6-b79e-686ca65c8a59", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3ee779a5-069d-4283-8419-54eaffdc5ef4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b35b410f-9eee-43bd-9126-b077ef0f2180");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b29acd41-03f1-4e61-9118-19e90b170330", "4675ccef-fde3-4751-8c15-707127b41c64", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "916c7bfd-7cda-4aa2-bede-7233f49f6cc4", "391c7753-88d9-4083-84b6-3994062a2a0c", "Administrator", "ADMINISTRATOR" });
        }
    }
}
