using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoAresInfer.Migrations
{
    public partial class fixcolumnas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agencias",
                columns: table => new
                {
                    AgenciaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CodigoAgencia = table.Column<int>(type: "INTEGER", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agencias", x => x.AgenciaId);
                });

            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    EmpresaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CifEmpresa = table.Column<string>(type: "TEXT", maxLength: 9, nullable: false),
                    RazonSocial = table.Column<string>(type: "TEXT", maxLength: 55, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.EmpresaId);
                });

            migrationBuilder.CreateTable(
                name: "Trabajadores",
                columns: table => new
                {
                    TrabajadorId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FechaRegistro = table.Column<DateTime>(type: "DATE", nullable: false),
                    Dni = table.Column<string>(type: "TEXT", maxLength: 9, nullable: false),
                    Apellido1 = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Apellido2 = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    Nombre = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "DATE", maxLength: 8, nullable: false),
                    Sexo = table.Column<char>(type: "TEXT", nullable: false),
                    NivelFormativo = table.Column<string>(type: "TEXT", maxLength: 2, nullable: false),
                    Discapacidad = table.Column<char>(type: "TEXT", nullable: false),
                    Inmigrante = table.Column<char>(type: "TEXT", nullable: false),
                    Colocacion = table.Column<char>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trabajadores", x => x.TrabajadorId);
                });

            migrationBuilder.CreateTable(
                name: "Ofertas",
                columns: table => new
                {
                    OfertaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EmpresaId = table.Column<int>(type: "INTEGER", nullable: false),
                    Titulo = table.Column<string>(type: "varchar", maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(type: "varchar", nullable: true),
                    FechaOferta = table.Column<DateTime>(type: "DATE", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ofertas", x => x.OfertaId);
                    table.ForeignKey(
                        name: "FK_Ofertas_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "EmpresaId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "OfertaTrabajadores",
                columns: table => new
                {
                    OfertaTrabajadorId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OfertaId = table.Column<int>(type: "INTEGER", nullable: false),
                    TrabajadorId = table.Column<int>(type: "INTEGER", nullable: false),
                    FechaOfertaEnviada = table.Column<DateTime>(type: "DATE", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfertaTrabajadores", x => x.OfertaTrabajadorId);
                    table.ForeignKey(
                        name: "FK_OfertaTrabajadores_Ofertas_OfertaId",
                        column: x => x.OfertaId,
                        principalTable: "Ofertas",
                        principalColumn: "OfertaId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_OfertaTrabajadores_Trabajadores_TrabajadorId",
                        column: x => x.TrabajadorId,
                        principalTable: "Trabajadores",
                        principalColumn: "TrabajadorId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Colocaciones",
                columns: table => new
                {
                    ColocacionId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OfertaTrabajadorId = table.Column<int>(type: "INTEGER", nullable: false),
                    TipoContrato = table.Column<string>(type: "TEXT", maxLength: 3, nullable: false),
                    FechaColocacion = table.Column<DateTime>(type: "DATE", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colocaciones", x => x.ColocacionId);
                    table.ForeignKey(
                        name: "FK_Colocaciones_OfertaTrabajadores_OfertaTrabajadorId",
                        column: x => x.OfertaTrabajadorId,
                        principalTable: "OfertaTrabajadores",
                        principalColumn: "OfertaTrabajadorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Colocaciones_OfertaTrabajadorId",
                table: "Colocaciones",
                column: "OfertaTrabajadorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ofertas_EmpresaId",
                table: "Ofertas",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_OfertaTrabajadores_OfertaId",
                table: "OfertaTrabajadores",
                column: "OfertaId");

            migrationBuilder.CreateIndex(
                name: "IX_OfertaTrabajadores_TrabajadorId",
                table: "OfertaTrabajadores",
                column: "TrabajadorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agencias");

            migrationBuilder.DropTable(
                name: "Colocaciones");

            migrationBuilder.DropTable(
                name: "OfertaTrabajadores");

            migrationBuilder.DropTable(
                name: "Ofertas");

            migrationBuilder.DropTable(
                name: "Trabajadores");

            migrationBuilder.DropTable(
                name: "Empresas");
        }
    }
}
