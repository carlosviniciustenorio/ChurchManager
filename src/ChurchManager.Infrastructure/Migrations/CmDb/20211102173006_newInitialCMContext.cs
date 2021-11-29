using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ChurchManager.Infrastructure.Migrations.CmDb
{
    public partial class newInitialCMContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Igreja",
                columns: table => new
                {
                    DirigenteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID = table.Column<int>(type: "int", nullable: false),
                    Cnpj = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RazaoSocial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ativa = table.Column<bool>(type: "bit", nullable: false),
                    Matriz = table.Column<bool>(type: "bit", nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cep = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Igreja", x => x.DirigenteId);
                });

            migrationBuilder.CreateTable(
                name: "Membro",
                columns: table => new
                {
                    IgrejaId = table.Column<int>(type: "int", nullable: false),
                    ID = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Foto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataDeNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sexo = table.Column<int>(type: "int", nullable: false),
                    RG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomePai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomeMae = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstadoCivil = table.Column<int>(type: "int", nullable: false),
                    DataDeCasamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NomeConjuge = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataDeNascimentoConjuge = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Celular = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataDoBatismo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IgrejaAnterior = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomeDoPastorAnterior = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Funcao = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Membro", x => x.IgrejaId);
                    table.ForeignKey(
                        name: "FK_Membro_Igreja_IgrejaId",
                        column: x => x.IgrejaId,
                        principalTable: "Igreja",
                        principalColumn: "DirigenteId",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Membro");

            migrationBuilder.DropTable(
                name: "Igreja");
        }
    }
}
