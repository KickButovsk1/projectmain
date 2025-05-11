using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NagruzkaClg.Migrations
{
    /// <inheritdoc />
    public partial class InitialTest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseLevel = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Disciplines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FreeOrSpend",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FreeSpend = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FreeOrSpend", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ObuchenieForm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Form = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObuchenieForm", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Specializes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specializes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpecializeId = table.Column<int>(type: "int", nullable: false),
                    FreeOrSpendId = table.Column<int>(type: "int", nullable: false),
                    ObuchenieFormId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Groups_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Groups_FreeOrSpend_FreeOrSpendId",
                        column: x => x.FreeOrSpendId,
                        principalTable: "FreeOrSpend",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Groups_ObuchenieForm_ObuchenieFormId",
                        column: x => x.ObuchenieFormId,
                        principalTable: "ObuchenieForm",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Groups_Specializes_SpecializeId",
                        column: x => x.SpecializeId,
                        principalTable: "Specializes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Plan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeoryHours = table.Column<int>(type: "int", nullable: false),
                    Semestr = table.Column<int>(type: "int", nullable: false),
                    PracticeHours = table.Column<int>(type: "int", nullable: false),
                    SelfHours = table.Column<int>(type: "int", nullable: false),
                    KursHours = table.Column<int>(type: "int", nullable: false),
                    SpecializeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plan_Specializes_SpecializeId",
                        column: x => x.SpecializeId,
                        principalTable: "Specializes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Nagruzka",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DisciplineId = table.Column<int>(type: "int", nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    PlanId = table.Column<int>(type: "int", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nagruzka", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nagruzka_Disciplines_DisciplineId",
                        column: x => x.DisciplineId,
                        principalTable: "Disciplines",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Nagruzka_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Nagruzka_Plan_PlanId",
                        column: x => x.PlanId,
                        principalTable: "Plan",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Nagruzka_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Load",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoadsHours = table.Column<int>(type: "int", nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    NagruzkaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Load", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Load_Nagruzka_NagruzkaId",
                        column: x => x.NagruzkaId,
                        principalTable: "Nagruzka",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Load_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Groups_CourseId",
                table: "Groups",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_FreeOrSpendId",
                table: "Groups",
                column: "FreeOrSpendId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_ObuchenieFormId",
                table: "Groups",
                column: "ObuchenieFormId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_SpecializeId",
                table: "Groups",
                column: "SpecializeId");

            migrationBuilder.CreateIndex(
                name: "IX_Load_NagruzkaId",
                table: "Load",
                column: "NagruzkaId");

            migrationBuilder.CreateIndex(
                name: "IX_Load_TeacherId",
                table: "Load",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Nagruzka_DisciplineId",
                table: "Nagruzka",
                column: "DisciplineId");

            migrationBuilder.CreateIndex(
                name: "IX_Nagruzka_GroupId",
                table: "Nagruzka",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Nagruzka_PlanId",
                table: "Nagruzka",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_Nagruzka_TeacherId",
                table: "Nagruzka",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Plan_SpecializeId",
                table: "Plan",
                column: "SpecializeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Load");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Nagruzka");

            migrationBuilder.DropTable(
                name: "Disciplines");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Plan");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "FreeOrSpend");

            migrationBuilder.DropTable(
                name: "ObuchenieForm");

            migrationBuilder.DropTable(
                name: "Specializes");
        }
    }
}
