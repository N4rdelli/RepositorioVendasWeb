using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppVendasWeb.Migrations
{
    /// <inheritdoc />
    public partial class NovaVenda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NovaVenda",
                columns: table => new
                {
                    NovaVendaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NotaFiscal = table.Column<int>(type: "int", nullable: true),
                    DataVenda = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProdutoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TotalProdutos = table.Column<double>(type: "float", nullable: false),
                    TotalDesconto = table.Column<double>(type: "float", nullable: false),
                    PercentualDesconto = table.Column<double>(type: "float", nullable: false),
                    TotalFinal = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NovaVenda", x => x.NovaVendaId);
                    table.ForeignKey(
                        name: "FK_NovaVenda_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NovaVenda_Produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produto",
                        principalColumn: "ProdutoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NovaVenda_ClienteId",
                table: "NovaVenda",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_NovaVenda_ProdutoId",
                table: "NovaVenda",
                column: "ProdutoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NovaVenda");
        }
    }
}
