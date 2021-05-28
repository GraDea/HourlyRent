using Microsoft.EntityFrameworkCore.Migrations;

namespace HourlyRate.Migrations
{
    public partial class PricesInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Prices",
                keyColumn: "Id",
                keyValue: 3,
                column: "ObjectId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Prices",
                keyColumn: "Id",
                keyValue: 4,
                column: "ObjectId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Prices",
                keyColumn: "Id",
                keyValue: 5,
                column: "ObjectId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Prices",
                keyColumn: "Id",
                keyValue: 6,
                column: "ObjectId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Prices",
                keyColumn: "Id",
                keyValue: 7,
                column: "ObjectId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Prices",
                keyColumn: "Id",
                keyValue: 8,
                column: "ObjectId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Prices",
                keyColumn: "Id",
                keyValue: 9,
                column: "ObjectId",
                value: 2);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Prices",
                keyColumn: "Id",
                keyValue: 3,
                column: "ObjectId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Prices",
                keyColumn: "Id",
                keyValue: 4,
                column: "ObjectId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Prices",
                keyColumn: "Id",
                keyValue: 5,
                column: "ObjectId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Prices",
                keyColumn: "Id",
                keyValue: 6,
                column: "ObjectId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Prices",
                keyColumn: "Id",
                keyValue: 7,
                column: "ObjectId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Prices",
                keyColumn: "Id",
                keyValue: 8,
                column: "ObjectId",
                value: 8);

            migrationBuilder.UpdateData(
                table: "Prices",
                keyColumn: "Id",
                keyValue: 9,
                column: "ObjectId",
                value: 9);
        }
    }
}
