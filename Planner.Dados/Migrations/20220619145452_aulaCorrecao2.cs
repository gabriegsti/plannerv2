using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Planner.Dados.Migrations
{
    public partial class aulaCorrecao2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Anotacao_Aula_AulaId_Aula",
                table: "Anotacao");

            migrationBuilder.RenameColumn(
                name: "AulaId_Aula",
                table: "Anotacao",
                newName: "AulaId");

            migrationBuilder.RenameIndex(
                name: "IX_Anotacao_AulaId_Aula",
                table: "Anotacao",
                newName: "IX_Anotacao_AulaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Anotacao_Aula_AulaId",
                table: "Anotacao",
                column: "AulaId",
                principalTable: "Aula",
                principalColumn: "Id_Aula",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Anotacao_Aula_AulaId",
                table: "Anotacao");

            migrationBuilder.RenameColumn(
                name: "AulaId",
                table: "Anotacao",
                newName: "AulaId_Aula");

            migrationBuilder.RenameIndex(
                name: "IX_Anotacao_AulaId",
                table: "Anotacao",
                newName: "IX_Anotacao_AulaId_Aula");

            migrationBuilder.AddForeignKey(
                name: "FK_Anotacao_Aula_AulaId_Aula",
                table: "Anotacao",
                column: "AulaId_Aula",
                principalTable: "Aula",
                principalColumn: "Id_Aula",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
