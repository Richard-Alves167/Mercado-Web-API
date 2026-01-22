namespace Mercado_Web_API.Models.Relationships {
    public class FornecedorProduto {
        public FornecedorProduto(int fornecedorId, int produtoId) {
            FornecedorId = fornecedorId;
            ProdutoId = produtoId;
        }
        public int FornecedorId { get; set; }
        public Fornecedor Fornecedor { get; set; }
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
    }
}
