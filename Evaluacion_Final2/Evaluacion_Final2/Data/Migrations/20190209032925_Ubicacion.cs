using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Evaluacion_Final2.Data.Migrations
{
    public partial class Ubicacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ubicacion",
                columns: table => new
                {
                    idUbicacion = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Detalle = table.Column<string>(nullable: true),
                    idDisco = table.Column<int>(nullable: false),
                    idInformacion = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ubicacion", x => x.idUbicacion);
                    table.ForeignKey(
                        name: "FK_Ubicacion_Disco_idDisco",
                        column: x => x.idDisco,
                        principalTable: "Disco",
                        principalColumn: "idDisco",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ubicacion_Informacion_idInformacion",
                        column: x => x.idInformacion,
                        principalTable: "Informacion",
                        principalColumn: "idInformacion",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ubicacion_idDisco",
                table: "Ubicacion",
                column: "idDisco");

            migrationBuilder.CreateIndex(
                name: "IX_Ubicacion_idInformacion",
                table: "Ubicacion",
                column: "idInformacion");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ubicacion");
        }
    }
}
