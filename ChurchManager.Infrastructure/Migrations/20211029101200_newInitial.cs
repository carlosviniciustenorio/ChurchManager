using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ChurchManager.Infrastructure.Migrations
{
    public partial class newInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Membro",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    IgrejaId = table.Column<int>(type: "int", nullable: false),
                    NomeDoPastorAnterior = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Funcao = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Membro", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Igreja",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cnpj = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RazaoSocial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ativa = table.Column<bool>(type: "bit", nullable: false),
                    Matriz = table.Column<bool>(type: "bit", nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cep = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DirigenteId = table.Column<int>(type: "int", nullable: false),
                    DirigenteID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Igreja", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Igreja_Membro_DirigenteID",
                        column: x => x.DirigenteID,
                        principalTable: "Membro",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Igreja_DirigenteID",
                table: "Igreja",
                column: "DirigenteID");

            migrationBuilder.CreateIndex(
                name: "IX_Membro_IgrejaId",
                table: "Membro",
                column: "IgrejaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Membro_Igreja_IgrejaId",
                table: "Membro",
                column: "IgrejaId",
                principalTable: "Igreja",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Igreja_Membro_DirigenteID",
                table: "Igreja");

            migrationBuilder.DropTable(
                name: "Membro");

            migrationBuilder.DropTable(
                name: "Igreja");
        }
    }
}
