using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppVendasWeb.Migrations
{
    /// <inheritdoc />
    public partial class NovaVenda2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NovaVenda_Produto_ProdutoId",
                table: "NovaVenda");

            migrationBuilder.DropIndex(
                name: "IX_NovaVenda_ProdutoId",
                table: "NovaVenda");

            migrationBuilder.DropColumn(
                name: "ProdutoId",
                table: "NovaVenda");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ProdutoId",
                table: "NovaVenda",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_NovaVenda_ProdutoId",
                table: "NovaVenda",
                column: "ProdutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_NovaVenda_Produto_ProdutoId",
                table: "NovaVenda",
                column: "ProdutoId",
                principalTable: "Produto",
                principalColumn: "ProdutoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
