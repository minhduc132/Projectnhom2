using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace agement2.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QLhocki",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QLhocki", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QLmonhoc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Semester = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QLmonhoc", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QLsinhvien",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phonenumber = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QLsinhvien", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QLdiem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Theory = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Practice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Exercise = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QLsinhvienId = table.Column<int>(type: "int", nullable: false),
                    QLhockiId = table.Column<int>(type: "int", nullable: true),
                    QLmonhocId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QLdiem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QLdiem_QLhocki_QLhockiId",
                        column: x => x.QLhockiId,
                        principalTable: "QLhocki",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_QLdiem_QLmonhoc_QLmonhocId",
                        column: x => x.QLmonhocId,
                        principalTable: "QLmonhoc",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_QLdiem_QLsinhvien_QLsinhvienId",
                        column: x => x.QLsinhvienId,
                        principalTable: "QLsinhvien",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QLdiem_QLhockiId",
                table: "QLdiem",
                column: "QLhockiId");

            migrationBuilder.CreateIndex(
                name: "IX_QLdiem_QLmonhocId",
                table: "QLdiem",
                column: "QLmonhocId");

            migrationBuilder.CreateIndex(
                name: "IX_QLdiem_QLsinhvienId",
                table: "QLdiem",
                column: "QLsinhvienId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QLdiem");

            migrationBuilder.DropTable(
                name: "QLhocki");

            migrationBuilder.DropTable(
                name: "QLmonhoc");

            migrationBuilder.DropTable(
                name: "QLsinhvien");
        }
    }
}
