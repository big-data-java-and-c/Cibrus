using Microsoft.EntityFrameworkCore.Migrations;

namespace Cibrus.Migrations
{
    public partial class SeedGroupsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "group",
                columns: new[] { "id", "groupName" },
                values: new object[,]
                {
                    { 1, "IO1" },
                    { 2, "IO2" },
                    { 3, "IO3" },
                    { 4, "IO4" },
                    { 5, "IO5" },
                    { 6, "IO6" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "group",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "group",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "group",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "group",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "group",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "group",
                keyColumn: "id",
                keyValue: 6);
        }
    }
}
