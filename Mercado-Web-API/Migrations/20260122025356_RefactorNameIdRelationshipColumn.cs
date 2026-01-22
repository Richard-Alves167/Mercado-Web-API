using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mercado_Web_API.Migrations
{
    /// <inheritdoc />
    public partial class RefactorNameIdRelationshipColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compras_Clientes_IdCliente",
                table: "Compras");

            migrationBuilder.DropForeignKey(
                name: "FK_Itens_Compras_IdCompra",
                table: "Itens");

            migrationBuilder.DropForeignKey(
                name: "FK_Itens_Produtos_IdProduto",
                table: "Itens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FornecedoresProdutos",
                table: "FornecedoresProdutos");

            migrationBuilder.DropIndex(
                name: "IX_FornecedoresProdutos_FornecedorId",
                table: "FornecedoresProdutos");

            migrationBuilder.DropColumn(
                name: "IdFornecedor",
                table: "FornecedoresProdutos");

            migrationBuilder.DropColumn(
                name: "IdProduto",
                table: "FornecedoresProdutos");

            migrationBuilder.RenameColumn(
                name: "IdProduto",
                table: "Itens",
                newName: "ProdutoId");

            migrationBuilder.RenameColumn(
                name: "IdCompra",
                table: "Itens",
                newName: "CompraId");

            migrationBuilder.RenameIndex(
                name: "IX_Itens_IdProduto",
                table: "Itens",
                newName: "IX_Itens_ProdutoId");

            migrationBuilder.RenameIndex(
                name: "IX_Itens_IdCompra",
                table: "Itens",
                newName: "IX_Itens_CompraId");

            migrationBuilder.RenameColumn(
                name: "IdCliente",
                table: "Compras",
                newName: "ClienteId");

            migrationBuilder.RenameIndex(
                name: "IX_Compras_IdCliente",
                table: "Compras",
                newName: "IX_Compras_ClienteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FornecedoresProdutos",
                table: "FornecedoresProdutos",
                columns: new[] { "FornecedorId", "ProdutoId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Compras_Clientes_ClienteId",
                table: "Compras",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Itens_Compras_CompraId",
                table: "Itens",
                column: "CompraId",
                principalTable: "Compras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Itens_Produtos_ProdutoId",
                table: "Itens",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compras_Clientes_ClienteId",
                table: "Compras");

            migrationBuilder.DropForeignKey(
                name: "FK_Itens_Compras_CompraId",
                table: "Itens");

            migrationBuilder.DropForeignKey(
                name: "FK_Itens_Produtos_ProdutoId",
                table: "Itens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FornecedoresProdutos",
                table: "FornecedoresProdutos");

            migrationBuilder.RenameColumn(
                name: "ProdutoId",
                table: "Itens",
                newName: "IdProduto");

            migrationBuilder.RenameColumn(
                name: "CompraId",
                table: "Itens",
                newName: "IdCompra");

            migrationBuilder.RenameIndex(
                name: "IX_Itens_ProdutoId",
                table: "Itens",
                newName: "IX_Itens_IdProduto");

            migrationBuilder.RenameIndex(
                name: "IX_Itens_CompraId",
                table: "Itens",
                newName: "IX_Itens_IdCompra");

            migrationBuilder.RenameColumn(
                name: "ClienteId",
                table: "Compras",
                newName: "IdCliente");

            migrationBuilder.RenameIndex(
                name: "IX_Compras_ClienteId",
                table: "Compras",
                newName: "IX_Compras_IdCliente");

            migrationBuilder.AddColumn<int>(
                name: "IdFornecedor",
                table: "FornecedoresProdutos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdProduto",
                table: "FornecedoresProdutos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_FornecedoresProdutos",
                table: "FornecedoresProdutos",
                columns: new[] { "IdFornecedor", "IdProduto" });

            migrationBuilder.CreateIndex(
                name: "IX_FornecedoresProdutos_FornecedorId",
                table: "FornecedoresProdutos",
                column: "FornecedorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Compras_Clientes_IdCliente",
                table: "Compras",
                column: "IdCliente",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Itens_Compras_IdCompra",
                table: "Itens",
                column: "IdCompra",
                principalTable: "Compras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Itens_Produtos_IdProduto",
                table: "Itens",
                column: "IdProduto",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
