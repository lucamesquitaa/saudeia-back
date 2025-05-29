using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaudeIA.Migrations
{
    /// <inheritdoc />
    public partial class googl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hotel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Url = table.Column<string>(type: "text", nullable: false),
                    Rede = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Category = table.Column<int>(type: "integer", nullable: false),
                    Child = table.Column<bool>(type: "boolean", nullable: true),
                    Pets = table.Column<bool>(type: "boolean", nullable: true),
                    PetsTax = table.Column<double>(type: "double precision", nullable: true),
                    Cep = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    Number = table.Column<string>(type: "text", nullable: false),
                    Complement = table.Column<string>(type: "text", nullable: true),
                    Lobby = table.Column<string>(type: "text", nullable: true),
                    Diff = table.Column<string>(type: "text", nullable: true),
                    Beach = table.Column<bool>(type: "boolean", nullable: true),
                    Downtown = table.Column<bool>(type: "boolean", nullable: true),
                    Airpot = table.Column<bool>(type: "boolean", nullable: true),
                    Highway = table.Column<bool>(type: "boolean", nullable: true),
                    Hospital = table.Column<bool>(type: "boolean", nullable: true),
                    Coffee = table.Column<bool>(type: "boolean", nullable: true),
                    Wifi = table.Column<bool>(type: "boolean", nullable: true),
                    Swimming = table.Column<bool>(type: "boolean", nullable: true),
                    Cleaning = table.Column<bool>(type: "boolean", nullable: true),
                    Gym = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContatosModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DetalhesModelId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Contact = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContatosModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContatosModel_Hotel_DetalhesModelId",
                        column: x => x.DetalhesModelId,
                        principalTable: "Hotel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FotosDetalhesModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DetalhesModelId = table.Column<Guid>(type: "uuid", nullable: false),
                    Alt = table.Column<string>(type: "text", nullable: false),
                    Url = table.Column<string>(type: "text", nullable: false),
                    Stared = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FotosDetalhesModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FotosDetalhesModel_Hotel_DetalhesModelId",
                        column: x => x.DetalhesModelId,
                        principalTable: "Hotel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContatosModel_DetalhesModelId",
                table: "ContatosModel",
                column: "DetalhesModelId");

            migrationBuilder.CreateIndex(
                name: "IX_FotosDetalhesModel_DetalhesModelId",
                table: "FotosDetalhesModel",
                column: "DetalhesModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContatosModel");

            migrationBuilder.DropTable(
                name: "FotosDetalhesModel");

            migrationBuilder.DropTable(
                name: "Hotel");
        }
    }
}
