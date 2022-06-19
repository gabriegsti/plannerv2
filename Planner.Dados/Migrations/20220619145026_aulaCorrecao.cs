using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Planner.Dados.Migrations
{
    public partial class aulaCorrecao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id_Aula",
                table: "Anotacao",
                newName: "AulaId_Aula");

            migrationBuilder.CreateIndex(
                name: "IX_Anotacao_AulaId_Aula",
                table: "Anotacao",
                column: "AulaId_Aula");

            migrationBuilder.AddForeignKey(
                name: "FK_Anotacao_Aula_AulaId_Aula",
                table: "Anotacao",
                column: "AulaId_Aula",
                principalTable: "Aula",
                principalColumn: "Id_Aula",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Anotacao_Aula_AulaId_Aula",
                table: "Anotacao");

            migrationBuilder.DropIndex(
                name: "IX_Anotacao_AulaId_Aula",
                table: "Anotacao");

            migrationBuilder.RenameColumn(
                name: "AulaId_Aula",
                table: "Anotacao",
                newName: "Id_Aula");
        }
    }
}
