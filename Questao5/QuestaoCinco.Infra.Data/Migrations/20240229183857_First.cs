using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuestaoCinco.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContasCorrente",
                columns: table => new
                {
                    ContaId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    NomeTitular = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    ValorInicial = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    SaldoAtual = table.Column<decimal>(type: "decimal(10,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContasCorrente", x => x.ContaId);
                });

            migrationBuilder.CreateTable(
                name: "Lancamentos",
                columns: table => new
                {
                    LancamentoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DebitoCredito = table.Column<string>(type: "char(1)", nullable: true),
                    Valor = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    SaldoAntes = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    SaldoApos = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    DataTransacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    ContaId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lancamentos", x => x.LancamentoId);
                    table.ForeignKey(
                        name: "FK_Lancamentos_ContasCorrente_ContaId",
                        column: x => x.ContaId,
                        principalTable: "ContasCorrente",
                        principalColumn: "ContaId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lancamentos_ContaId",
                table: "Lancamentos",
                column: "ContaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lancamentos");

            migrationBuilder.DropTable(
                name: "ContasCorrente");
        }
    }
}
