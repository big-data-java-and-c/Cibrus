using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cibrus.Migrations
{
    public partial class finalMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "group",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    groupName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_group", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    role_type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "subject",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    value_ECTS = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subject", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    email = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true),
                    roles_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                    table.ForeignKey(
                        name: "FK_user_roles_roles_id",
                        column: x => x.roles_id,
                        principalTable: "roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "student",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    displayName = table.Column<string>(nullable: true),
                    address = table.Column<string>(nullable: true),
                    city = table.Column<string>(nullable: true),
                    province = table.Column<string>(nullable: true),
                    zip_code = table.Column<string>(nullable: true),
                    phone_number = table.Column<string>(nullable: true),
                    GropuId = table.Column<int>(nullable: false),
                    user_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_student", x => x.id);
                    table.ForeignKey(
                        name: "FK_student_group_GropuId",
                        column: x => x.GropuId,
                        principalTable: "group",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_student_user_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "teacher",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    salary = table.Column<int>(nullable: false),
                    user_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teacher", x => x.id);
                    table.ForeignKey(
                        name: "FK_teacher_user_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "grade",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    value_grade = table.Column<int>(nullable: false),
                    date_received = table.Column<string>(nullable: true),
                    SubjectId = table.Column<int>(nullable: false),
                    TeacherId = table.Column<int>(nullable: false),
                    StudentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_grade", x => x.id);
                    table.ForeignKey(
                        name: "FK_grade_student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "student",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_grade_subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "subject",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_grade_teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "teacher",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                    { 6, "IO6" },
                    { 7, "NewUserGroup" }
                });

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
                columns: new[] { "id", "GropuId", "user_id", "address", "city", "displayName", "phone_number", "province", "zip_code" },
                values: new object[,]
                {
                    { 1, 1, 1, " szkolna 11", " uć ", " Wiktor", "785772271", " lodzkie", "12-345" },
                    { 2, 1, 2, " szkolna 11", " uć ", " Kamil", "785772271", " lodzkie", "12-345" },
                    { 3, 2, 3, " szkolna 11", " uć ", " Rafał", "785772271", " lodzkie", "12-345" },
                    { 4, 2, 4, " robertowa 11", " uć ", " Robert", "733333271", " lodzkie", "12-345" }
                });

            migrationBuilder.InsertData(
                table: "teacher",
                columns: new[] { "id", "user_id", "name", "salary" },
                values: new object[] { 1, 3, "profesor", 15000 });

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
                    { 6, 2, 1, 1, "12/08/2019", 5 },
                    { 7, 4, 1, 1, "12/08/2019", 5 },
                    { 8, 4, 1, 1, "12/08/2019", 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_grade_StudentId",
                table: "grade",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_grade_SubjectId",
                table: "grade",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_grade_TeacherId",
                table: "grade",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_student_GropuId",
                table: "student",
                column: "GropuId");

            migrationBuilder.CreateIndex(
                name: "IX_student_user_id",
                table: "student",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_teacher_user_id",
                table: "teacher",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_roles_id",
                table: "user",
                column: "roles_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "grade");

            migrationBuilder.DropTable(
                name: "student");

            migrationBuilder.DropTable(
                name: "subject");

            migrationBuilder.DropTable(
                name: "teacher");

            migrationBuilder.DropTable(
                name: "group");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "roles");
        }
    }
}
