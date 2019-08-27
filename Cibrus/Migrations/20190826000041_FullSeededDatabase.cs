using Microsoft.EntityFrameworkCore.Migrations;

namespace Cibrus.Migrations
{
    public partial class FullSeededDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_student_group_GroupId",
                table: "student");

            migrationBuilder.DropIndex(
                name: "IX_student_GroupId",
                table: "student");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "student");

            migrationBuilder.InsertData(
                table: "grade",
                columns: new[] { "id", "StudentId", "SubjectId", "TeacherId", "date_received", "value_grade" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, "12/08/2019", 5 },
                    { 2, 1, 1, 1, "12/08/2019", 5 },
                    { 3, 1, 1, 1, "12/08/2019", 5 },
                    { 4, 1, 1, 1, "12/08/2019", 5 },
                    { 5, 2, 1, 1, "12/08/2019", 5 },
                    { 6, 2, 1, 1, "12/08/2019", 5 }
                });

            migrationBuilder.InsertData(
                table: "student",
                columns: new[] { "id", "GropuId", "user_id", "address", "city", "displayName", "phone_number", "province", "zip_code" },
                values: new object[,]
                {
                    { 3, 2, 3, " szkolna 11", " uć ", " Rafał", "785772271", " lodzkie", "12-345" },
                    { 4, 2, 4, " robertowa 11", " uć ", " Robert", "733333271", " lodzkie", "12-345" }
                });

            migrationBuilder.InsertData(
                table: "grade",
                columns: new[] { "id", "StudentId", "SubjectId", "TeacherId", "date_received", "value_grade" },
                values: new object[] { 7, 4, 1, 1, "12/08/2019", 5 });

            migrationBuilder.InsertData(
                table: "grade",
                columns: new[] { "id", "StudentId", "SubjectId", "TeacherId", "date_received", "value_grade" },
                values: new object[] { 8, 4, 1, 1, "12/08/2019", 5 });

            migrationBuilder.CreateIndex(
                name: "IX_student_GropuId",
                table: "student",
                column: "GropuId");

            migrationBuilder.AddForeignKey(
                name: "FK_student_group_GropuId",
                table: "student",
                column: "GropuId",
                principalTable: "group",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_student_group_GropuId",
                table: "student");

            migrationBuilder.DropIndex(
                name: "IX_student_GropuId",
                table: "student");

            migrationBuilder.DeleteData(
                table: "grade",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "grade",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "grade",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "grade",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "grade",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "grade",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "grade",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "grade",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "student",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "student",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "student",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_student_GroupId",
                table: "student",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_student_group_GroupId",
                table: "student",
                column: "GroupId",
                principalTable: "group",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
