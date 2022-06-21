using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Planner.Dados.Migrations
{
    public partial class inserindoDriverPostgres : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Materia",
                columns: table => new
                {
                    Id_Materia = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Id_Usuario = table.Column<int>(type: "integer", nullable: true),
                    Titulo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Professor = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Data_Inicio = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Data_Fim = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materia", x => x.Id_Materia);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id_Usuario = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Senha = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id_Usuario);
                });

            migrationBuilder.CreateTable(
                name: "Aula",
                columns: table => new
                {
                    Id_Aula = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Id_Materia = table.Column<int>(type: "integer", nullable: false),
                    Titulo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Data_Hora = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Link = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    MateriaId_Materia = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aula", x => x.Id_Aula);
                    table.ForeignKey(
                        name: "FK_Aula_Materia_MateriaId_Materia",
                        column: x => x.MateriaId_Materia,
                        principalTable: "Materia",
                        principalColumn: "Id_Materia");
                });

            migrationBuilder.CreateTable(
                name: "Evento",
                columns: table => new
                {
                    Id_Evento = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Titulo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Data_Hora = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UsuarioId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evento", x => x.Id_Evento);
                    table.ForeignKey(
                        name: "FK_Evento_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id_Usuario");
                });

            migrationBuilder.CreateTable(
                name: "Anotacao",
                columns: table => new
                {
                    Id_Anotacao = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AulaId = table.Column<int>(type: "integer", nullable: false),
                    Titulo = table.Column<string>(type: "text", nullable: false),
                    Campo_Texto = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Link = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anotacao", x => x.Id_Anotacao);
                    table.ForeignKey(
                        name: "FK_Anotacao_Aula_AulaId",
                        column: x => x.AulaId,
                        principalTable: "Aula",
                        principalColumn: "Id_Aula",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Avaliacao",
                columns: table => new
                {
                    Id_Avaliacao = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MateriaId = table.Column<int>(type: "integer", nullable: false),
                    Titulo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Nota = table.Column<double>(type: "double precision", nullable: true),
                    Data_Hora = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    EventoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avaliacao", x => x.Id_Avaliacao);
                    table.ForeignKey(
                        name: "FK_Avaliacao_Evento_EventoId",
                        column: x => x.EventoId,
                        principalTable: "Evento",
                        principalColumn: "Id_Evento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Avaliacao_Materia_MateriaId",
                        column: x => x.MateriaId,
                        principalTable: "Materia",
                        principalColumn: "Id_Materia",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Anotacao_AulaId",
                table: "Anotacao",
                column: "AulaId");

            migrationBuilder.CreateIndex(
                name: "IX_Aula_MateriaId_Materia",
                table: "Aula",
                column: "MateriaId_Materia");

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacao_EventoId",
                table: "Avaliacao",
                column: "EventoId");

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacao_MateriaId",
                table: "Avaliacao",
                column: "MateriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Evento_UsuarioId",
                table: "Evento",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Anotacao");

            migrationBuilder.DropTable(
                name: "Avaliacao");

            migrationBuilder.DropTable(
                name: "Aula");

            migrationBuilder.DropTable(
                name: "Evento");

            migrationBuilder.DropTable(
                name: "Materia");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
