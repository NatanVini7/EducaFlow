using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EducaFlow.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contatos",
                columns: table => new
                {
                    IdContato = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TelefoneContato = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailContato = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contatos", x => x.IdContato);
                });

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    IdEndereco = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Logradouro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Numero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Complemento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bairro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cep = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.IdEndereco);
                });

            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    IdAluno = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeAluno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    NomeSocial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrgaoEmissor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UFEmissor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroNisPisPasep = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroSus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomeMae = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomePai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroInep = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroRa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatadeNascimento = table.Column<DateOnly>(type: "date", nullable: false),
                    DatadeEmissao = table.Column<DateOnly>(type: "date", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Sexo = table.Column<int>(type: "int", nullable: false),
                    EstadoCivil = table.Column<int>(type: "int", nullable: false),
                    Etnia = table.Column<int>(type: "int", nullable: false),
                    Transporte = table.Column<int>(type: "int", nullable: false),
                    TipoTransporte = table.Column<int>(type: "int", nullable: false),
                    Alfabetizado = table.Column<bool>(type: "bit", nullable: false),
                    Deficiencia = table.Column<bool>(type: "bit", nullable: false),
                    DeficienciaEspecificar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Emancipado = table.Column<bool>(type: "bit", nullable: false),
                    ContatoIdContato = table.Column<int>(type: "int", nullable: true),
                    EnderecoIdEndereco = table.Column<int>(type: "int", nullable: true),
                    IdContato = table.Column<int>(type: "int", nullable: false),
                    IdEndereco = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.IdAluno);
                    table.ForeignKey(
                        name: "FK_Alunos_Contatos_ContatoIdContato",
                        column: x => x.ContatoIdContato,
                        principalTable: "Contatos",
                        principalColumn: "IdContato");
                    table.ForeignKey(
                        name: "FK_Alunos_Enderecos_EnderecoIdEndereco",
                        column: x => x.EnderecoIdEndereco,
                        principalTable: "Enderecos",
                        principalColumn: "IdEndereco");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_ContatoIdContato",
                table: "Alunos",
                column: "ContatoIdContato");

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_EnderecoIdEndereco",
                table: "Alunos",
                column: "EnderecoIdEndereco");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "Contatos");

            migrationBuilder.DropTable(
                name: "Enderecos");
        }
    }
}
