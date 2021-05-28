using Microsoft.EntityFrameworkCore.Migrations;

namespace HourlyRate.Migrations
{
    public partial class ImageInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ObjectImage_Objects_RealtyObjectId",
                table: "ObjectImage");

            migrationBuilder.AlterColumn<int>(
                name: "RealtyObjectId",
                table: "ObjectImage",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "ObjectImage",
                columns: new[] { "Id", "Priority", "RealtyObjectId", "Url" },
                values: new object[] { 1, 1, 1, "https://www.pogostite.ru/images/887/409/0/admin/images/conference_places/397/p1ccjm3g6qol31gkf163e1o8t1vni9o.jpg" });

            migrationBuilder.InsertData(
                table: "ObjectImage",
                columns: new[] { "Id", "Priority", "RealtyObjectId", "Url" },
                values: new object[] { 2, 1, 2, "https://www.pogostite.ru/images/887/409/0/admin/images/conference_places/397/p1ccjm3g6qol31gkf163e1o8t1vni9o.jpg" });

            migrationBuilder.InsertData(
                table: "ObjectImage",
                columns: new[] { "Id", "Priority", "RealtyObjectId", "Url" },
                values: new object[] { 3, 1, 3, "https://www.pogostite.ru/images/887/409/0/admin/images/conference_places/397/p1ccjm3g6qol31gkf163e1o8t1vni9o.jpg" });

            migrationBuilder.AddForeignKey(
                name: "FK_ObjectImage_Objects_RealtyObjectId",
                table: "ObjectImage",
                column: "RealtyObjectId",
                principalTable: "Objects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ObjectImage_Objects_RealtyObjectId",
                table: "ObjectImage");

            migrationBuilder.DeleteData(
                table: "ObjectImage",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ObjectImage",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ObjectImage",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<int>(
                name: "RealtyObjectId",
                table: "ObjectImage",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ObjectImage_Objects_RealtyObjectId",
                table: "ObjectImage",
                column: "RealtyObjectId",
                principalTable: "Objects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
