using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Planner.Dados.Migrations
{
    public partial class alteracao_anotacao_link : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "Anotacao",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Link",
                table: "Anotacao");
        }
    }
}
