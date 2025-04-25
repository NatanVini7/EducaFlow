using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EducaFlow.Migrations.Curso
{
    /// <inheritdoc />
    public partial class CriacaoCurso : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cursos",
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
                    table.PrimaryKey("PK_Cursos", x => x.IdCurso);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cursos");
        }
    }
}
