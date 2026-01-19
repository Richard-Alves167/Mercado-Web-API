using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mercado_Web_API.Migrations
{
    /// <inheritdoc />
    public partial class AddContextRelationshipFornecedorProduto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FornecedorProduto_Fornecedores_FornecedorId",
                table: "FornecedorProduto");

            migrationBuilder.DropForeignKey(
                name: "FK_FornecedorProduto_Produtos_ProdutoId",
                table: "FornecedorProduto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FornecedorProduto",
                table: "FornecedorProduto");

            migrationBuilder.RenameTable(
                name: "FornecedorProduto",
                newName: "FornecedoresProdutos");

            migrationBuilder.RenameIndex(
                name: "IX_FornecedorProduto_ProdutoId",
                table: "FornecedoresProdutos",
                newName: "IX_FornecedoresProdutos_ProdutoId");

            migrationBuilder.RenameIndex(
                name: "IX_FornecedorProduto_FornecedorId",
                table: "FornecedoresProdutos",
                newName: "IX_FornecedoresProdutos_FornecedorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FornecedoresProdutos",
                table: "FornecedoresProdutos",
                columns: new[] { "IdFornecedor", "IdProduto" });

            migrationBuilder.AddForeignKey(
                name: "FK_FornecedoresProdutos_Fornecedores_FornecedorId",
                table: "FornecedoresProdutos",
                column: "FornecedorId",
                principalTable: "Fornecedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FornecedoresProdutos_Produtos_ProdutoId",
                table: "FornecedoresProdutos",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FornecedoresProdutos_Fornecedores_FornecedorId",
                table: "FornecedoresProdutos");

            migrationBuilder.DropForeignKey(
                name: "FK_FornecedoresProdutos_Produtos_ProdutoId",
                table: "FornecedoresProdutos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FornecedoresProdutos",
                table: "FornecedoresProdutos");

            migrationBuilder.RenameTable(
                name: "FornecedoresProdutos",
                newName: "FornecedorProduto");

            migrationBuilder.RenameIndex(
                name: "IX_FornecedoresProdutos_ProdutoId",
                table: "FornecedorProduto",
                newName: "IX_FornecedorProduto_ProdutoId");

            migrationBuilder.RenameIndex(
                name: "IX_FornecedoresProdutos_FornecedorId",
                table: "FornecedorProduto",
                newName: "IX_FornecedorProduto_FornecedorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FornecedorProduto",
                table: "FornecedorProduto",
                columns: new[] { "IdFornecedor", "IdProduto" });

            migrationBuilder.AddForeignKey(
                name: "FK_FornecedorProduto_Fornecedores_FornecedorId",
                table: "FornecedorProduto",
                column: "FornecedorId",
                principalTable: "Fornecedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FornecedorProduto_Produtos_ProdutoId",
                table: "FornecedorProduto",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
