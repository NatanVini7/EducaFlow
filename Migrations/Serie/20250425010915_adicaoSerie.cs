using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EducaFlow.Migrations.Serie
{
    /// <inheritdoc />
    public partial class adicaoSerie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Curso",
                columns: table => new
                {
                    IdCurso = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodCurso = table.Column<int>(type: "int", nullable: false),
                    NomeCurso = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SiglaCurso = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QtdEtapas = table.Column<int>(type: "int", nullable: false),
                    NiveisEnsino = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curso", x => x.IdCurso);
                });

            migrationBuilder.CreateTable(
                name: "Series",
                columns: table => new
                {
                    IdSerie = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodSerie = table.Column<int>(type: "int", nullable: false),
                    CursoIdCurso = table.Column<int>(type: "int", nullable: false),
                    NomeSerie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EtapaCurso = table.Column<int>(type: "int", nullable: false),
                    RegraAvaliacao = table.Column<int>(type: "int", nullable: false),
                    Concluinte = table.Column<bool>(type: "bit", nullable: false),
                    CargaHoraria = table.Column<float>(type: "real", nullable: false),
                    DiasLetivos = table.Column<int>(type: "int", nullable: false),
                    IdCurso = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Series", x => x.IdSerie);
                    table.ForeignKey(
                        name: "FK_Series_Curso_CursoIdCurso",
                        column: x => x.CursoIdCurso,
                        principalTable: "Curso",
                        principalColumn: "IdCurso",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Series_CursoIdCurso",
                table: "Series",
                column: "CursoIdCurso");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Series");

            migrationBuilder.DropTable(
                name: "Curso");
        }
    }
}
