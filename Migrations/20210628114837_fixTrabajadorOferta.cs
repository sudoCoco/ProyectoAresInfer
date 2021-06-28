using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoAresInfer.Migrations
{
    public partial class fixTrabajadorOferta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<char>(
                name: "Prestacion",
                table: "Trabajadores",
                type: "TEXT",
                nullable: false,
                defaultValue: 'N');

            migrationBuilder.AddColumn<int>(
                name: "Puesto",
                table: "Ofertas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Prestacion",
                table: "Trabajadores");

            migrationBuilder.DropColumn(
                name: "Puesto",
                table: "Ofertas");
        }
    }
}
