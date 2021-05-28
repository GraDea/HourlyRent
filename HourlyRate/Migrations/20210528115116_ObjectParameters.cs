using Microsoft.EntityFrameworkCore.Migrations;

namespace HourlyRate.Migrations
{
    public partial class ObjectParameters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Capacity",
                table: "Objects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Lat",
                table: "Objects",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Lon",
                table: "Objects",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Objects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Region",
                table: "Objects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TotalSpace",
                table: "Objects",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "EventType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventTypeRealtyObject",
                columns: table => new
                {
                    AvailableEventTypesId = table.Column<int>(type: "int", nullable: false),
                    ObjectsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTypeRealtyObject", x => new { x.AvailableEventTypesId, x.ObjectsId });
                    table.ForeignKey(
                        name: "FK_EventTypeRealtyObject_EventType_AvailableEventTypesId",
                        column: x => x.AvailableEventTypesId,
                        principalTable: "EventType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventTypeRealtyObject_Objects_ObjectsId",
                        column: x => x.ObjectsId,
                        principalTable: "Objects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "EventType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Митап" },
                    { 2, "Хакатон" },
                    { 3, "Конференция" },
                    { 4, "Мастер-класс" }
                });

            migrationBuilder.UpdateData(
                table: "Objects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Capacity", "Description", "Rating", "Region", "Title", "TotalSpace" },
                values: new object[] { 100, "Уютный лофт на Бауманской", 5, "ЮЗАО", "Уютный лофт на Бауманской", 250.0 });

            migrationBuilder.UpdateData(
                table: "Objects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Capacity", "Description", "Rating", "Region", "Title", "TotalSpace" },
                values: new object[] { 10, "Уютный лофт на Бауманской", 5, "ВАО", "Уютный лофт на Бауманской", 50.0 });

            migrationBuilder.UpdateData(
                table: "Objects",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Capacity", "Description", "Rating", "Region", "Title", "TotalSpace" },
                values: new object[] { 300, "Уютный лофт на Бауманской", 5, "ЗАО", "Уютный лофт на Бауманской", 1000.0 });

            migrationBuilder.CreateIndex(
                name: "IX_EventTypeRealtyObject_ObjectsId",
                table: "EventTypeRealtyObject",
                column: "ObjectsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventTypeRealtyObject");

            migrationBuilder.DropTable(
                name: "EventType");

            migrationBuilder.DropColumn(
                name: "Capacity",
                table: "Objects");

            migrationBuilder.DropColumn(
                name: "Lat",
                table: "Objects");

            migrationBuilder.DropColumn(
                name: "Lon",
                table: "Objects");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Objects");

            migrationBuilder.DropColumn(
                name: "Region",
                table: "Objects");

            migrationBuilder.DropColumn(
                name: "TotalSpace",
                table: "Objects");

            migrationBuilder.UpdateData(
                table: "Objects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Title" },
                values: new object[] { "TEst 1", "sadas asdasdasd" });

            migrationBuilder.UpdateData(
                table: "Objects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Title" },
                values: new object[] { "TEst 1", "asdasdasdasdas" });

            migrationBuilder.UpdateData(
                table: "Objects",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Title" },
                values: new object[] { "TEst 1", "asdasdasdasdas" });
        }
    }
}
