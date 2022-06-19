using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Planner.Dados.Migrations
{
    public partial class alteracaonocampousuarioid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id_Usuario",
                table: "Evento");

            migrationBuilder.RenameColumn(
                name: "Id_Materia",
                table: "Avaliacao",
                newName: "MateriaId");

            migrationBuilder.RenameColumn(
                name: "Id_Evento",
                table: "Avaliacao",
                newName: "EventoId");

            migrationBuilder.AlterColumn<string>(
                name: "Titulo",
                table: "Evento",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Evento",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Evento_UsuarioId",
                table: "Evento",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacao_EventoId",
                table: "Avaliacao",
                column: "EventoId");

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacao_MateriaId",
                table: "Avaliacao",
                column: "MateriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Avaliacao_Evento_EventoId",
                table: "Avaliacao",
                column: "EventoId",
                principalTable: "Evento",
                principalColumn: "Id_Evento",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Avaliacao_Materia_MateriaId",
                table: "Avaliacao",
                column: "MateriaId",
                principalTable: "Materia",
                principalColumn: "Id_Materia",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Evento_Usuario_UsuarioId",
                table: "Evento",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id_Usuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Avaliacao_Evento_EventoId",
                table: "Avaliacao");

            migrationBuilder.DropForeignKey(
                name: "FK_Avaliacao_Materia_MateriaId",
                table: "Avaliacao");

            migrationBuilder.DropForeignKey(
                name: "FK_Evento_Usuario_UsuarioId",
                table: "Evento");

            migrationBuilder.DropIndex(
                name: "IX_Evento_UsuarioId",
                table: "Evento");

            migrationBuilder.DropIndex(
                name: "IX_Avaliacao_EventoId",
                table: "Avaliacao");

            migrationBuilder.DropIndex(
                name: "IX_Avaliacao_MateriaId",
                table: "Avaliacao");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Evento");

            migrationBuilder.RenameColumn(
                name: "MateriaId",
                table: "Avaliacao",
                newName: "Id_Materia");

            migrationBuilder.RenameColumn(
                name: "EventoId",
                table: "Avaliacao",
                newName: "Id_Evento");

            migrationBuilder.AlterColumn<string>(
                name: "Titulo",
                table: "Evento",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<int>(
                name: "Id_Usuario",
                table: "Evento",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
