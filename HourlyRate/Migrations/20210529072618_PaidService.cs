using Microsoft.EntityFrameworkCore.Migrations;

namespace HourlyRate.Migrations
{
    public partial class PaidService : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PaidServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaidServices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaidServiceRealtyBooking",
                columns: table => new
                {
                    BookingsId = table.Column<int>(type: "int", nullable: false),
                    PaidServicesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaidServiceRealtyBooking", x => new { x.BookingsId, x.PaidServicesId });
                    table.ForeignKey(
                        name: "FK_PaidServiceRealtyBooking_Bookings_BookingsId",
                        column: x => x.BookingsId,
                        principalTable: "Bookings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaidServiceRealtyBooking_PaidServices_PaidServicesId",
                        column: x => x.PaidServicesId,
                        principalTable: "PaidServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaidServiceRealtyObject",
                columns: table => new
                {
                    ObjectsId = table.Column<int>(type: "int", nullable: false),
                    PaidServicesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaidServiceRealtyObject", x => new { x.ObjectsId, x.PaidServicesId });
                    table.ForeignKey(
                        name: "FK_PaidServiceRealtyObject_Objects_ObjectsId",
                        column: x => x.ObjectsId,
                        principalTable: "Objects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaidServiceRealtyObject_PaidServices_PaidServicesId",
                        column: x => x.PaidServicesId,
                        principalTable: "PaidServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PaidServices",
                columns: new[] { "Id", "Price", "Title" },
                values: new object[] { 1, 1000m, "Фотограф" });

            migrationBuilder.InsertData(
                table: "PaidServices",
                columns: new[] { "Id", "Price", "Title" },
                values: new object[] { 2, 2000m, "Шоу мыльных пузырей" });

            migrationBuilder.CreateIndex(
                name: "IX_PaidServiceRealtyBooking_PaidServicesId",
                table: "PaidServiceRealtyBooking",
                column: "PaidServicesId");

            migrationBuilder.CreateIndex(
                name: "IX_PaidServiceRealtyObject_PaidServicesId",
                table: "PaidServiceRealtyObject",
                column: "PaidServicesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaidServiceRealtyBooking");

            migrationBuilder.DropTable(
                name: "PaidServiceRealtyObject");

            migrationBuilder.DropTable(
                name: "PaidServices");
        }
    }
}
