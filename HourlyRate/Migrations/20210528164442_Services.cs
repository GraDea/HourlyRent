using Microsoft.EntityFrameworkCore.Migrations;

namespace HourlyRate.Migrations
{
    public partial class Services : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Objects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RealtyObjectService",
                columns: table => new
                {
                    ObjectsId = table.Column<int>(type: "int", nullable: false),
                    ServicesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealtyObjectService", x => new { x.ObjectsId, x.ServicesId });
                    table.ForeignKey(
                        name: "FK_RealtyObjectService_Objects_ObjectsId",
                        column: x => x.ObjectsId,
                        principalTable: "Objects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RealtyObjectService_Services_ServicesId",
                        column: x => x.ServicesId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Objects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Address", "Region" },
                values: new object[] { "Моховая, д. 12", "ЦАО" });

            migrationBuilder.UpdateData(
                table: "Objects",
                keyColumn: "Id",
                keyValue: 2,
                column: "Address",
                value: "Измайловская, д. 1");

            migrationBuilder.UpdateData(
                table: "Objects",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Address", "Region" },
                values: new object[] { "Изумрудная д. 23", "САО" });

            migrationBuilder.UpdateData(
                table: "Objects",
                keyColumn: "Id",
                keyValue: 4,
                column: "Address",
                value: "Митинское шоссе, д. 23");

            migrationBuilder.UpdateData(
                table: "Objects",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Address", "Region" },
                values: new object[] { "Большая Черемушкинская, д. 5", "ЮЗАО" });

            migrationBuilder.UpdateData(
                table: "Objects",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Address", "Region" },
                values: new object[] { "Кубанская, д. 23", "ЮВАО" });

            migrationBuilder.UpdateData(
                table: "Objects",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Address", "Region" },
                values: new object[] { "Профсоюзная, д. 1", "ЮЗАО" });

            migrationBuilder.UpdateData(
                table: "Objects",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Address", "Region" },
                values: new object[] { "Нахимовский проспект, д. 44", "ЮАО" });

            migrationBuilder.UpdateData(
                table: "Objects",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Address", "Region" },
                values: new object[] { "Аэродромная, д. 11", "СЗАО" });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, null },
                    { 2, null },
                    { 3, null },
                    { 4, null },
                    { 5, null },
                    { 6, null },
                    { 7, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RealtyObjectService_ServicesId",
                table: "RealtyObjectService",
                column: "ServicesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RealtyObjectService");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Objects");

            migrationBuilder.UpdateData(
                table: "Objects",
                keyColumn: "Id",
                keyValue: 1,
                column: "Region",
                value: "ЮЗАО");

            migrationBuilder.UpdateData(
                table: "Objects",
                keyColumn: "Id",
                keyValue: 3,
                column: "Region",
                value: "ЗАО");

            migrationBuilder.UpdateData(
                table: "Objects",
                keyColumn: "Id",
                keyValue: 5,
                column: "Region",
                value: "ЗАО");

            migrationBuilder.UpdateData(
                table: "Objects",
                keyColumn: "Id",
                keyValue: 6,
                column: "Region",
                value: "ЗАО");

            migrationBuilder.UpdateData(
                table: "Objects",
                keyColumn: "Id",
                keyValue: 7,
                column: "Region",
                value: "ЗАО");

            migrationBuilder.UpdateData(
                table: "Objects",
                keyColumn: "Id",
                keyValue: 8,
                column: "Region",
                value: "ЗАО");

            migrationBuilder.UpdateData(
                table: "Objects",
                keyColumn: "Id",
                keyValue: 9,
                column: "Region",
                value: "ЗАО");
        }
    }
}
