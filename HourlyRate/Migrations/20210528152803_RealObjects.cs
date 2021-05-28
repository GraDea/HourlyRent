using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HourlyRate.Migrations
{
    public partial class RealObjects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Prices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ObjectId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Day = table.Column<int>(type: "int", nullable: true),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prices_Objects_ObjectId",
                        column: x => x.ObjectId,
                        principalTable: "Objects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ObjectId = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    From = table.Column<DateTime>(type: "datetime2", nullable: false),
                    To = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_Objects_ObjectId",
                        column: x => x.ObjectId,
                        principalTable: "Objects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Ssss" });

            migrationBuilder.UpdateData(
                table: "ObjectImage",
                keyColumn: "Id",
                keyValue: 1,
                column: "Url",
                value: "https://www.loft2rent.ru/upload_data/2021/9738/upld8RaD9b.jpg.1200x800.jpg");

            migrationBuilder.UpdateData(
                table: "ObjectImage",
                keyColumn: "Id",
                keyValue: 2,
                column: "Url",
                value: "https://www.loft2rent.ru/upload_data/2021/5926/upldevJpmc.JPG.1200x800.jpg");

            migrationBuilder.UpdateData(
                table: "ObjectImage",
                keyColumn: "Id",
                keyValue: 3,
                column: "Url",
                value: "https://www.loft2rent.ru/upload_data/2020/9920/upldkN6dzo.jpg.900x600.jpg");

            migrationBuilder.UpdateData(
                table: "Objects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Capacity", "Description", "Title", "TotalSpace" },
                values: new object[] { 20, "Легко разместит 150-200 человек театральной рассадкой, а проектор, предназначенный специально для светлых помещений четко и ярко продемонстрирует все подготовленные презентационные материалы.", "Белый зал", 150.0 });

            migrationBuilder.UpdateData(
                table: "Objects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Capacity", "Description", "Title", "TotalSpace" },
                values: new object[] { 60, "Обустроенное и комфортабельное пространство подходит для любых бизнес- и образовательных мероприятий: бизнес встречи, презентации, конференции, тренинги, семинары, мастер классы. Любое из них пройдёт на высшем уровне.", "Конференц-зал Восток Центр", 78.0 });

            migrationBuilder.UpdateData(
                table: "Objects",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Capacity", "Description", "Title", "TotalSpace" },
                values: new object[] { 20, "Новейший лофт в самом центре Москвы с отдельным парадным входом и панорамными окнами. Специально построен для качественного и комфортного проведения клиентских мероприятий любых форматов.", "PLART", 50.0 });

            migrationBuilder.InsertData(
                table: "Objects",
                columns: new[] { "Id", "Capacity", "Description", "Lat", "Lon", "ObjectType", "Rating", "Region", "Title", "TotalSpace" },
                values: new object[,]
                {
                    { 8, 50, "Мы — большое, атмосферное, стильное пространство, созданное для проведения самых по истине крутых вечеринок, фотосессий, лекций, мастер-классов, дней рождения, свадеб и много другого.", null, null, 1, 5, "ЗАО", "Garden", 230.0 },
                    { 7, 30, "Хотите устроить вечеринку, посиделки с друзьями за любимой видеоигрой или уединённое свидание под любимый фильм на большом экране? Добро пожаловать в антикинотеатр «Дубль Три». Бронируйте любую из трёх тематических комнат и отдыхайте так, как вам нравится!", null, null, 1, 5, "ЗАО", "Антикинотеатр \"Дубль Три\"", 90.0 },
                    { 6, 50, "Студия для виртуальных и онлайн-мероприятий с полным сопровождением. Среди наших клиентов Роскомос, Сбербанк, Тинькофф, Первый канал.", null, null, 1, 5, "ЗАО", "Duo Screen", 150.0 },
                    { 5, 50, "Жан Бодрийяр утверждал, что зеркало придает пространству завершенность... А мы придаем завершенность Вашему празднику", null, null, 1, 5, "ЗАО", "Арт-пространство в Измаильском кремле", 110.0 },
                    { 4, 20, "Уютный лофт с кухней для проведения праздников, съемок, мастер-классов, вечеринок. Проводим мастер-классы по готовке от именитых шеф-поваров и гастронамические баталии!\r\n                                                            Поможем с организацией вашего мероприятия: подбором шеф-повара, согласованием меню, подбором интерактивного наполнения праздника.\r\n                                                            ", null, null, 1, 5, "ЗАО", "Петух в вине", 50.0 },
                    { 9, 20, "Лофт-кальянная с караоке, с профессиональными концертным музоборудованием. Уютный квартирный интерьер с барной зоной, подготовленный по звуку и климату для проведения домашних концертов, караоке вечеринок, фуршетов и праздников в теплой компании с дымными кальянами.", null, null, 1, 5, "ЗАО", "Кальян-бар", 50.0 }
                });

            migrationBuilder.InsertData(
                table: "Prices",
                columns: new[] { "Id", "Amount", "Day", "EndTime", "ObjectId", "StartTime" },
                values: new object[,]
                {
                    { 1, 5000m, null, null, 1, null },
                    { 2, 5000m, null, null, 2, null },
                    { 3, 6000m, null, null, 2, null },
                    { 5, 3000m, null, null, 2, null },
                    { 6, 10000m, null, null, 2, null },
                    { 7, 8000m, null, null, 2, null },
                    { 8, 2000m, null, null, 2, null },
                    { 9, 1000m, null, null, 2, null },
                    { 4, 4000m, null, null, 2, null }
                });

            migrationBuilder.InsertData(
                table: "ObjectImage",
                columns: new[] { "Id", "Priority", "RealtyObjectId", "Url" },
                values: new object[,]
                {
                    { 4, 1, 4, "https://bash.today/storage/uploads/spaces/2781/lg_c5d3d727-db85-4ee4-92e9-03028d0fb6c0.jpeg" },
                    { 5, 1, 5, "https://bash.today/storage/uploads/spaces/3822/lg_a9c3bf4c-a095-4acc-8b7c-57f95363eb2c.jpg" },
                    { 6, 1, 6, "https://bash.today/storage/uploads/spaces/3736/lg_e94a6ee7-b38f-42b4-add6-85c593ba73d5.jpg" },
                    { 7, 1, 7, "https://bash.today/storage/uploads/spaces/4072/lg_b4cc1dbe-6049-4221-8f88-ada08964eb53.jpeg" },
                    { 8, 1, 8, "https://www.loft2rent.ru/upload_data/2020/2200/upldyLoMLy.jpg.900x600.jpg" },
                    { 9, 1, 9, "https://www.loft2rent.ru/upload_data/2020/2200/upldyLoMLy.jpg.900x600.jpg" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ClientId",
                table: "Bookings",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ObjectId",
                table: "Bookings",
                column: "ObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Prices_ObjectId",
                table: "Prices",
                column: "ObjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Prices");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DeleteData(
                table: "ObjectImage",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ObjectImage",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ObjectImage",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ObjectImage",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ObjectImage",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ObjectImage",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Objects",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Objects",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Objects",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Objects",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Objects",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Objects",
                keyColumn: "Id",
                keyValue: 9);

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

            migrationBuilder.UpdateData(
                table: "ObjectImage",
                keyColumn: "Id",
                keyValue: 1,
                column: "Url",
                value: "https://www.pogostite.ru/images/887/409/0/admin/images/conference_places/397/p1ccjm3g6qol31gkf163e1o8t1vni9o.jpg");

            migrationBuilder.UpdateData(
                table: "ObjectImage",
                keyColumn: "Id",
                keyValue: 2,
                column: "Url",
                value: "https://www.pogostite.ru/images/887/409/0/admin/images/conference_places/397/p1ccjm3g6qol31gkf163e1o8t1vni9o.jpg");

            migrationBuilder.UpdateData(
                table: "ObjectImage",
                keyColumn: "Id",
                keyValue: 3,
                column: "Url",
                value: "https://www.pogostite.ru/images/887/409/0/admin/images/conference_places/397/p1ccjm3g6qol31gkf163e1o8t1vni9o.jpg");

            migrationBuilder.UpdateData(
                table: "Objects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Capacity", "Description", "Title", "TotalSpace" },
                values: new object[] { 100, "Уютный лофт на Бауманской", "Уютный лофт на Бауманской", 250.0 });

            migrationBuilder.UpdateData(
                table: "Objects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Capacity", "Description", "Title", "TotalSpace" },
                values: new object[] { 10, "Уютный лофт на Бауманской", "Уютный лофт на Бауманской", 50.0 });

            migrationBuilder.UpdateData(
                table: "Objects",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Capacity", "Description", "Title", "TotalSpace" },
                values: new object[] { 300, "Уютный лофт на Бауманской", "Уютный лофт на Бауманской", 1000.0 });
        }
    }
}
