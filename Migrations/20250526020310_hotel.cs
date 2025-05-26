using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaudeIA.Migrations
{
    /// <inheritdoc />
    public partial class hotel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Body");

            migrationBuilder.DropTable(
                name: "Metas");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.CreateTable(
                name: "Hotel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Url = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Category = table.Column<int>(type: "integer", nullable: false),
                    Child = table.Column<bool>(type: "boolean", nullable: false),
                    Pets = table.Column<bool>(type: "boolean", nullable: false),
                    PetsTax = table.Column<double>(type: "double precision", nullable: true),
                    Cep = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    Number = table.Column<string>(type: "text", nullable: false),
                    Complement = table.Column<string>(type: "text", nullable: true),
                    Beach = table.Column<bool>(type: "boolean", nullable: true),
                    Downtown = table.Column<bool>(type: "boolean", nullable: true),
                    Airpot = table.Column<bool>(type: "boolean", nullable: true),
                    Highway = table.Column<bool>(type: "boolean", nullable: true),
                    Hospital = table.Column<bool>(type: "boolean", nullable: true)
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
                    Url = table.Column<string>(type: "text", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Body",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Altura = table.Column<double>(type: "double precision", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IMC = table.Column<double>(type: "double precision", nullable: false),
                    Peso = table.Column<double>(type: "double precision", nullable: false),
                    UserModelId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Body", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Body_User_UserModelId",
                        column: x => x.UserModelId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Metas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Frequency = table.Column<int>(type: "integer", nullable: false),
                    Hour = table.Column<int>(type: "integer", nullable: false),
                    State = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    UserModelId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Metas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Metas_User_UserModelId",
                        column: x => x.UserModelId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Body_UserModelId",
                table: "Body",
                column: "UserModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Metas_UserModelId",
                table: "Metas",
                column: "UserModelId");
        }
    }
}
