using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoAresInfer.Migrations
{
    public partial class fixtrabajador : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Colocacion",
                table: "Trabajadores");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<char>(
                name: "Colocacion",
                table: "Trabajadores",
                type: "TEXT",
                nullable: false,
                defaultValue: ' ');
        }
    }
}
