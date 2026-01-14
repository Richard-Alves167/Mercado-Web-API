namespace Mercado_Web_API.Models.Relationships {
    public class FornecedorProduto {
        public FornecedorProduto(int idFornecedor, int idProduto) {
            IdFornecedor = idFornecedor;
            IdProduto = idProduto;
        }
        public int IdFornecedor { get; set; }
        public Fornecedor Fornecedor { get; set; }
        public int IdProduto { get; set; }
        public Produto Produto { get; set; }
    }
}
