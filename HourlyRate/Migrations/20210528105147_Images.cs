using Microsoft.EntityFrameworkCore.Migrations;

namespace HourlyRate.Migrations
{
    public partial class Images : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ObjectImage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    RealtyObjectId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjectImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ObjectImage_Objects_RealtyObjectId",
                        column: x => x.RealtyObjectId,
                        principalTable: "Objects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Objects",
                keyColumn: "Id",
                keyValue: 1,
                column: "Title",
                value: "sadas asdasdasd");

            migrationBuilder.CreateIndex(
                name: "IX_ObjectImage_RealtyObjectId",
                table: "ObjectImage",
                column: "RealtyObjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ObjectImage");

            migrationBuilder.UpdateData(
                table: "Objects",
                keyColumn: "Id",
                keyValue: 1,
                column: "Title",
                value: "asdasdasdasdas");
        }
    }
}
