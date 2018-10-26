using Microsoft.EntityFrameworkCore.Migrations;

namespace Spd3.Migrations
{
    public partial class Modify_RegionIdValues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Regions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Order",
                value: 26);

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Name", "Order" },
                values: new object[] { "Донецька область", 5 });

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Name", "Order" },
                values: new object[] { "Закарпатська область", 7 });

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Name", "Order" },
                values: new object[] { "Луганська область", 12 });

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Name", "Order" },
                values: new object[] { "Миколаївська область", 14 });

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Name", "Order" },
                values: new object[] { "Сумська область", 18 });

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "Name", "Order" },
                values: new object[] { "Херсонська область", 21 });

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "Name", "Order" },
                values: new object[] { "Черкаська область", 23 });

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "Name", "Order" },
                values: new object[] { "Київ (місто)", 1 });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Name", "Order" },
                values: new object[,]
                {
                    { 6, "Житомирська область", 6 },
                    { 25, "Чернігівська область", 25 },
                    { 24, "Чернівецька область", 24 },
                    { 22, "Хмельницька область", 22 },
                    { 20, "Харківська область", 20 },
                    { 19, "Тернопільська область", 19 },
                    { 17, "Рівненська область", 17 },
                    { 16, "Полтавська область", 16 },
                    { 15, "Одеська область", 15 },
                    { 13, "Львівська область", 13 },
                    { 2, "Вінницька область", 2 },
                    { 11, "Кіровоградська область", 11 },
                    { 10, "Київська область", 10 },
                    { 9, "Івано-Франківська область", 9 },
                    { 8, "Запорізька область", 8 },
                    { 3, "Волинська область", 3 },
                    { 4, "Дніпропетровська область", 4 },
                    { 27, "Севастополь (місто)", 27 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DropColumn(
                name: "Order",
                table: "Regions");

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Вінницька область");

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "Волинська область");

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 12,
                column: "Name",
                value: "Дніпропетровська область");

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 14,
                column: "Name",
                value: "Донецька область");

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 18,
                column: "Name",
                value: "Житомирська область");

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 21,
                column: "Name",
                value: "Закарпатська область");

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 23,
                column: "Name",
                value: "Запорізька область");

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 26,
                column: "Name",
                value: "Івано-Франківська область");

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 80, "Київ (місто)" },
                    { 73, "Чернівецька область" },
                    { 71, "Черкаська область" },
                    { 68, "Хмельницька область" },
                    { 65, "Херсонська область" },
                    { 63, "Харківська область" },
                    { 61, "Тернопільська область" },
                    { 59, "Сумська область" },
                    { 46, "Львівська область" },
                    { 53, "Полтавська область" },
                    { 51, "Одеська область" },
                    { 48, "Миколаївська область" },
                    { 74, "Чернігівська область" },
                    { 44, "Луганська область" },
                    { 35, "Кіровоградська область" },
                    { 32, "Київська область" },
                    { 56, "Рівненська область" },
                    { 85, "Севастополь (місто)" }
                });
        }
    }
}
