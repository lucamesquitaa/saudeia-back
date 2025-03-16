using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaudeIA.Migrations
{
    /// <inheritdoc />
    public partial class enuns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Metas");

            migrationBuilder.AddColumn<int>(
                name: "Frequency",
                table: "Metas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Hour",
                table: "Metas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Frequency",
                table: "Metas");

            migrationBuilder.DropColumn(
                name: "Hour",
                table: "Metas");

            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "Metas",
                type: "int",
                nullable: true);
        }
    }
}
