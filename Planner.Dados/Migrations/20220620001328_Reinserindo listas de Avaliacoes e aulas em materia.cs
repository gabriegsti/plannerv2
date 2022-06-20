using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Planner.Dados.Migrations
{
    public partial class ReinserindolistasdeAvaliacoeseaulasemmateria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Professor",
                table: "Materia",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Materia",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "MateriaId_Materia",
                table: "Aula",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Aula_MateriaId_Materia",
                table: "Aula",
                column: "MateriaId_Materia");

            migrationBuilder.AddForeignKey(
                name: "FK_Aula_Materia_MateriaId_Materia",
                table: "Aula",
                column: "MateriaId_Materia",
                principalTable: "Materia",
                principalColumn: "Id_Materia");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aula_Materia_MateriaId_Materia",
                table: "Aula");

            migrationBuilder.DropIndex(
                name: "IX_Aula_MateriaId_Materia",
                table: "Aula");

            migrationBuilder.DropColumn(
                name: "MateriaId_Materia",
                table: "Aula");

            migrationBuilder.AlterColumn<string>(
                name: "Professor",
                table: "Materia",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Materia",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
