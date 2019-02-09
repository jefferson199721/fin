using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Evaluacion_Final2.Data.Migrations
{
    public partial class Informacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Informacion",
                columns: table => new
                {
                    idInformacion = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ubicacion = table.Column<string>(nullable: true),
                    Detalle = table.Column<string>(nullable: true),
                    Tamaño = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true),
                    Fecha = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Informacion", x => x.idInformacion);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Informacion");
        }
    }
}
