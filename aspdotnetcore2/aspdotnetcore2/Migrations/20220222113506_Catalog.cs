using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aspdotnetcore2.Migrations
{
    public partial class Catalog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Catalog",
                table: "Movie",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Catalog",
                table: "Movie");
        }
    }
}
