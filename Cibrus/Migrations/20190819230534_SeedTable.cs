using Microsoft.EntityFrameworkCore.Migrations;

namespace Cibrus.Migrations
{
    public partial class SeedTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "salary",
                table: "teacher",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "id", "role_type" },
                values: new object[,]
                {
                    { 1, "ADMIN" },
                    { 2, "STUDENT" },
                    { 3, "TEACHER" }
                });

            migrationBuilder.InsertData(
                table: "subject",
                columns: new[] { "id", "name", "value_ECTS" },
                values: new object[,]
                {
                    { 1, "Matematyka Dyskretna", 6 },
                    { 2, "Analiza Matematyczna", 5 },
                    { 3, "Podstawy Programowania", 4 }
                });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "id", "roles_id", "email", "password" },
                values: new object[,]
                {
                    { 5, 1, "admin@wp.pl", "12345" },
                    { 1, 2, "ekoGroszek@wp.pl", "12345" },
                    { 2, 2, "xewionn@wp.pl", "12345" },
                    { 6, 2, "student6@wp.pl", "12345" },
                    { 3, 3, "profesor@wp.pl", "12345" },
                    { 4, 3, "doktor@wp.pl", "12345" }
                });

            migrationBuilder.InsertData(
                table: "student",
                columns: new[] { "id", "GropuId", "GroupId", "user_id", "address", "city", "displayName", "phone_number", "province", "zip_code" },
                values: new object[] { 1, 1, null, 1, " szkolna 11", " uć ", " Wiktor", "785772271", " lodzkie", "12-345" });

            migrationBuilder.InsertData(
                table: "student",
                columns: new[] { "id", "GropuId", "GroupId", "user_id", "address", "city", "displayName", "phone_number", "province", "zip_code" },
                values: new object[] { 2, 1, null, 2, " szkolna 11", " uć ", " Kamil", "785772271", " lodzkie", "12-345" });

            migrationBuilder.InsertData(
                table: "teacher",
                columns: new[] { "id", "user_id", "name", "salary" },
                values: new object[] { 1, 3, "profesor", 15000 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "student",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "student",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "subject",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "subject",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "subject",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "teacher",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "salary",
                table: "teacher");
        }
    }
}
