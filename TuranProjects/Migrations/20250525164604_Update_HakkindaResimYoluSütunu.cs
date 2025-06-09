using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TuranProjects_Portfolio.Migrations
{
    /// <inheritdoc />
    public partial class Update_HakkindaResimYoluSütunu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ResimYolu",
                table: "Hakkindas",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResimYolu",
                table: "Hakkindas");
        }
    }
}
