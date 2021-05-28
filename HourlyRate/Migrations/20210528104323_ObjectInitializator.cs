using Microsoft.EntityFrameworkCore.Migrations;

namespace HourlyRate.Migrations
{
    public partial class ObjectInitializator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Objects",
                columns: new[] { "Id", "Description", "ObjectType", "Title" },
                values: new object[] { 1, "TEst 1", 1, "asdasdasdasdas" });

            migrationBuilder.InsertData(
                table: "Objects",
                columns: new[] { "Id", "Description", "ObjectType", "Title" },
                values: new object[] { 2, "TEst 1", 1, "asdasdasdasdas" });

            migrationBuilder.InsertData(
                table: "Objects",
                columns: new[] { "Id", "Description", "ObjectType", "Title" },
                values: new object[] { 3, "TEst 1", 1, "asdasdasdasdas" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DeleteData(
                table: "Objects",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Objects",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Objects",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
