using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Usuario.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PrimeiroNome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    UltimoNome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Genero = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Telefone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioLocalizacoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Cidade = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Pais = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    IdUsuario = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioLocalizacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioLocalizacoes_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioLocalizacoes_IdUsuario",
                table: "UsuarioLocalizacoes",
                column: "IdUsuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsuarioLocalizacoes");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
